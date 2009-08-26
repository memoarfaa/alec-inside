//---------------------------------------------------------------------------
#include <algorithm>
#include <limits>
#include <functional>
#include <assert.h>
#pragma hdrstop
#include "utils.h"

#include "Ship.h"
#include "Drawer.h"
#include "Players.h"
//---------------------------------------------------------------------------

// --- Player ---
Player::Player() {
	//������� ���� ���
	bf = new Battlefield( ROWS, COLUMNS  );
	//��������� �������
	ships_.push_back( new Ship( 1 ) );
	ships_.push_back( new Ship( 1 ) );
	ships_.push_back( new Ship( 1 ) );
	ships_.push_back( new Ship( 2 ) );
	ships_.push_back( new Ship( 2 ) );
	ships_.push_back( new Ship( 3 ) );
	ships_.push_back( new Ship( 3 ) );
	ships_.push_back( new Ship( 4 ) );
}
Player::~Player() {
	//������� �������
	std::for_each( ships_.begin(), ships_.end(), wipe<Ship> );
	//������� ���� ���
	delete bf;
}
bool Player::HasLiveShips() const {
	//���� ����� �������
	return ( std::find_if( ships_.begin(), ships_.end(),
		std::mem_fun( &Ship::IsLive ) ) != ships_.end() );
}
void Player::CheckShip( const Ship* s ) {
	if ( !s->IsLive() ) {
		std::cout << "�������� " << s->DeckCount() <<
			"-�������� �������" << std::endl;
	}
}

// --- Human ---

void Human::BaseShips() {
	std::cout << "���������� ���� �������. "
		"������� ������ ������ ������ � ����� �����." << std::endl;
	Drawer::Draw( Field(), true );
	for ( ShipIter it( ships_.begin() ); it != ships_.end(); ++it ) {
		while ( !TryBaseShip( *it ) );
		Drawer::Draw( Field(), true );
	}
}
bool Human::DropBomb( const Player* enemy ) {
	Drawer::Draw( Field(), true );
	Drawer::Draw( enemy->Field(), false );

	std::cout << "���� ���. �������!" << std::endl;
	int x = RequestCoordinate( enemy->Field()->ColumnCount(), "X: " );
	int y = RequestCoordinate( enemy->Field()->RowCount(), "Y: " );
	switch( enemy->Field()->DropBomb( x, y ) ) {
		case srAgain:
			std::cout << "�� ���� ��� �������. �� ����� �������!" <<
				std::endl;
			return DropBomb( enemy );
		case srEmpty:
			std::cout << "������." << std::endl;
			break;
		case srSuccess:
			std::cout << "������� �������. �����!" << std::endl;
			CheckShip( ( *( enemy->Field()->GetSquare( x, y ) ) )->GetShip() );
			if ( !enemy->HasLiveShips() ) {
				std::cout << "����������, �� �������!" << std::endl;
				return true;
			}
			return DropBomb( enemy );
	}
	return false;
}
bool Human::TryBaseShip( Ship* s ) const {
	std::cout << "���������� " << s->DeckCount() <<
		"-�������� �������." << std::endl;
	if ( s->DeckCount() > 1 ) {
		int align = Console::Request<int>( "���������� ������� "
			"(0 - ��������������, 1 - ������������):" );
		s->SetAlign( ShipAlign( align == 0 ? 0 : 1 ) );
	}

	int x = RequestCoordinate( Field()->ColumnCount(),
		"X ���������� ����:" );
	int y = RequestCoordinate( Field()->RowCount(),
		"Y ���������� ����:" );

	if ( !Field()->BaseShip( x, y, s ) ) {
		std::cout << "����� ������ ��������� �������. "
			"���������� �����." << std::endl;
		return false;
	}
	return true;
}
int Human::RequestCoordinate( int maxValue, std::string coordName ) {
	int coord = 0;
	do {
		if ( coord != 0 ) {
			std::cout << "�������� ����������. ������� �����." <<
				std::endl;
		}
		coord = Console::Request<int>( coordName );
	}
	while( coord < 0 || coord >= maxValue );
	return coord;
}


// --- Computer ---
Computer::Computer( Battlefield* enemyField )
	: Player(), squares_( enemyField->GetSquares() ) {
}
void Computer::BaseShips( ) {
	for ( ShipIter it( ships_.begin() ); it != ships_.end(); ++it ) {
		int x, y;
		do {
			x = RandomRange( 0, Field()->ColumnCount() - 1 );
			y = RandomRange( 0, Field()->RowCount() - 1 );
			(*it)->SetAlign( ShipAlign( RandomRange( 0, 1 ) ) );
		}
		while( !Field()->BaseShip( x, y, *it ) );
	}
}
bool Computer::DropBomb( const Player* enemy ) {
	std::cout << "� ����." << std::endl;

	BattleSquare* square = FetchNextSquare();

	std::cout << "������� ���: �= " << square->X() << " , Y= " <<
		square->Y() << std::endl;

	switch( square->DropBomb() ) {
		case srEmpty:
			std::cout << "��������." << std::endl;
			break;
		case srSuccess:
			std::cout << "� �����!" << std::endl;
			CheckShip( square->GetShip() );
			if ( !enemy->HasLiveShips() ) {
				std::cout << "� ���-���� � �������! ����� ����! :P" <<
					std::endl;
				return true;
			}

			lastShipSquares_.push_back( square );
			//���� ������� ����
			if ( !square->GetShip()->IsLive() ) {
				//������� ��� �������� ������
				for( BattleSquareConstIter it ( lastShipSquares_.begin() ) ;
					it != lastShipSquares_.end(); ++it ) {
					RemoveAdjacentSquares( *it );
				}
				lastShipSquares_.clear();
			}
			return DropBomb( enemy );
	}
	return false;
}


//������� �������� ������ ��� square
void Computer::RemoveAdjacentSquares( BattleSquare* square ) {
	squares_.erase(
		std::remove_if( squares_.begin(), squares_.end(),
			SquareAdjacentFinder( square, false ) ) ,
		squares_.end()
	);
}
//������� ��������� ������� �� ������ ��������������
BattleSquare* Computer::FetchNextSquare() {
	//���� ��� ��������������� �������
	if ( lastShipSquares_.empty() ) {
		//����� ��������� �������
		int squareIndex = RandomRange( 0, squares_.size() - 1 );
		BattleSquare* square = squares_[ squareIndex ];
		//������� ��� �� ������
		squares_.erase( squares_.begin() + squareIndex );
		return square;
	}
	// ���� ������ ���� ���
	else if ( lastShipSquares_.size() == 1 ) {
		int x = lastShipSquares_[0]->X();
		int y = lastShipSquares_[0]->Y();
		//�� ��������� ��������� �������� ��������
		//��� �� �������� ���� ��������� ������� ����
		BattleSquareIter itResult( ChooseIter(
			ChooseIter( Find( x - 1, y ) , Find( x + 1, y ) ),
			ChooseIter( Find( x, y - 1 ) , Find( x, y + 1 ) ))
		);
		assert( itResult != squares_.end() );
		BattleSquare* square = *itResult;
		squares_.erase( itResult );
		return square;
	}
	//���� ������ ����� ��� 1 ���
	else {
		//�� ��� �������� ���������� �������
		ShipAlign align = lastShipSquares_[0]->GetShip()->GetAlign();

		if ( align == saHorizontal ) {
			int Y = lastShipSquares_[0]->Y();
			int minX = lastShipSquares_[0]->X();
			int maxX = 0;
			//��������� �-� ��������� ���������
			for ( BattleSquareConstIter it( lastShipSquares_.begin() ) ;
				it != lastShipSquares_.end(); ++it ) {
				maxX = std::max( (*it)->X(), maxX );
				minX = std::min( (*it)->X(), minX );
			}
			//�������� ������� ����� ��� ������ ��������, ���� ��� �������
			//���� � ������
			BattleSquareIter itResult(
				ChooseIter( Find( minX - 1, Y ), Find( maxX + 1, Y ) ) );
			assert( itResult != squares_.end() );
			BattleSquare* square = *itResult;
			squares_.erase( itResult );
			return square;
		}
		else {
			int X = lastShipSquares_[0]->X();
			int minY = lastShipSquares_[0]->Y();
			int maxY = 0;
			for ( BattleSquareConstIter it( lastShipSquares_.begin() ) ;
				it != lastShipSquares_.end(); ++it ) {
				maxY = std::max( (*it)->Y(), maxY );
				minY = std::min( (*it)->Y(), minY );
			}
			BattleSquareIter itResult(
				ChooseIter( Find( X, minY - 1 ), Find( X , maxY + 1 ) ) );

			BattleSquare* square = *itResult;
			squares_.erase( itResult );
			return square;
		}
	}
}

BattleSquareIter Computer::ChooseIter( BattleSquareIter it1,
	BattleSquareIter it2 ) {

	if ( it1 != squares_.end() && it2 != squares_.end() ) {
			return  ( RandomRange( 0, 1 ) == 1 ? it1 : it2 );
	}
	else if ( it1 != squares_.end() ) {
			return it1;
	}
	return it2;
}

BattleSquareIter Computer::Find( int x, int y ) {
	return std::find_if( squares_.begin(), squares_.end(),
				SquareCoordFinder( x, y ) );
}




