//---------------------------------------------------------------------------

#ifndef PlayersH
#define PlayersH
#include <vector>
#include "Battlefield.h"
//---------------------------------------------------------------------------

const int ROWS = 10;
const int COLUMNS = 10;


class Ship;
class BattlefieldDrawer;

class Player {
	public:
		typedef std::vector<Ship*>::const_iterator ShipIter;
		typedef BattlefieldDrawer Drawer;

		Player();
		virtual ~Player();
		//���������� �������
		virtual void BaseShips() = 0;
		//������ �����
		virtual bool DropBomb( const Player* enemy ) = 0;
		// ���� ��� ��� �����?
		bool HasLiveShips() const;
		// ���� ���
		Battlefield* Field() const { return bf; }
	protected:
		// ������ �������� ������
		std::vector<Ship*> ships_;
		//��������� �� �������� �� �������
		static void CheckShip( const Ship* s );
	private:
		//���� ���
		Battlefield* bf;
};

//�������
class Human : public Player {
	public:
		void BaseShips();
		bool DropBomb( const Player* enemy );
	private:
		bool TryBaseShip( Ship* s ) const;
		static int RequestCoordinate( int maxValue, std::string coordName );
};

//���������
class Computer : public Player {
	public:
		//��������� ����� ��������� ����������
		Computer( Battlefield* enemyField );
		void BaseShips();
		bool DropBomb( const Player* enemy );
	private:
		//������ �������������� ��������� ����������
		std::vector<BattleSquare*> squares_;
		//������ ��������� ���������� ������������� �������
		std::vector<BattleSquare*> lastShipSquares_;

		//������� �������� ������ ��� square
		void RemoveAdjacentSquares( BattleSquare* square );
		//������� ��������� ������� �� ������ ��������������
		BattleSquare* FetchNextSquare();
		// ������� ���� �� ���� ����������
		BattleSquareIter ChooseIter( BattleSquareIter it1,
			BattleSquareIter it2 );
		// ����� ��������
		BattleSquareIter Find( int x, int y );
};


#endif
