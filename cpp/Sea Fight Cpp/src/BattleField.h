//---------------------------------------------------------------------------

#ifndef BattleFieldH
#define BattleFieldH
#include <vector>
//---------------------------------------------------------------------------
class Ship;
// ��������� ��������: { �����, ����, ��� ��� }
enum ShootResult { srSuccess, srEmpty, srAgain };

// ������� ���� ���
class BattleSquare {
	public:
		// ��� �� ��� ���������
		bool IsBombed() const { return bombed_; }
		// ���� �� � �������� �������
		bool HasShip() const { return ship_ != NULL; }
		// ���������� ������� ��� NULL
		Ship* GetShip() const { return ship_; }
		// x ���������� ��������
		int X() const { return x_; }
		// � ���������� ��������
		int Y() const { return y_; }
		// �������� �� ������� �������� (��� ����� �����)
		bool IsAdjacentOrSelf( const BattleSquare* other ) const;
		// �������� �� ������� �������� (�������� ������������)
		bool IsAdjacentStraight( const BattleSquare* other ) const;
		// �������� �����
		ShootResult DropBomb();
	private:
		// ����������� �������� ������ ������� ������
		// ��������� ���������� ��������
		BattleSquare( int x, int y ) : x_(x), y_(y), bombed_(false) {
			ship_ = NULL;
		}
		//��������� ������� � �������
		//������ ������ ����� ������ ���
		void SetShip( Ship* s ) { ship_ = s; }

		//����������� �� ���������
		BattleSquare( const BattleSquare& other );
		BattleSquare& operator=( const BattleSquare& other );
		//�������
		Ship* ship_;
		int x_;
		int y_;
		//���������?
		bool bombed_;
		// ����� ���� ��� ����� ��������� ��������
		friend class Battlefield;
};

typedef std::vector<BattleSquare*>::const_iterator BattleSquareConstIter;
typedef std::vector<BattleSquare*>::iterator BattleSquareIter;

//���� ���
class Battlefield {
	public:
		/* rowCount - ����� �����
		   columnCount - ����� �������� */
		Battlefield( int rowCount, int columnCount );
		virtual ~Battlefield();
		// ���������� ����� ������ ���������
		std::vector<BattleSquare*> GetSquares() const;
		//��������
		ShootResult DropBomb( int x, int y );
		//���������� ������� s
		// x,y - ���������� �������� � ������� ����� ������� ��� �������
		// ���������� ���������� ����������
		bool BaseShip( int x, int y, Ship* s );

		int ColumnCount() const {
			return columnCount_;
		}
		int RowCount() const {
			return rowCount_;
		}

		bool SquareExists( int x, int y ) const;
		//���������� �������� ��� ��������
		BattleSquareConstIter GetSquare( int x, int y) const;
	private:
		int rowCount_;
		int columnCount_;
		//��������
		std::vector<BattleSquare*> squares_;

		//����������� �� ���������
		Battlefield( const Battlefield& other );
		Battlefield& operator=( const Battlefield& other );

		//�������� �� ���������� �������
		//��� ������� ���������� � ������� *headSquareIter
		bool AllowBaseShip( const Ship* s,
			BattleSquareConstIter headSquareIter ) const;
};


// �������������� ������ ��� ������ ������ �� �����������
class SquareCoordFinder {
	public:
		SquareCoordFinder( int x, int y ) : x_( x ), y_( y ) { }
		bool operator()( const BattleSquare* square ) const {
			return square->X() == x_ && square->Y() == y_;
		}
	private:
		int x_;
		int y_;
};

// �������������� ������ ��� ������ �������� ������ � ���������
class SquareAdjacentWithShipFinder {
	public:
		SquareAdjacentWithShipFinder( BattleSquare* square ) {
			square_ = square;
		}
		bool operator()( const BattleSquare* other ) const {
			if ( square_->IsAdjacentOrSelf( other ) && other->HasShip() ) {
				return true;
			}
			return false;
		}
	private:
		//������������ ��������
		BattleSquare* square_;
};
// �������������� ������ ��� ������ �������� ���������
// �������� (straightOnly = true) ��� ������� ������������
class SquareAdjacentFinder {
	public:
		SquareAdjacentFinder( BattleSquare* square, bool straightOnly )
			: straightOnly_( straightOnly ) {
			square_ = square;
		}
		bool operator()( const BattleSquare* other ) const {
			return ( straightOnly_ ? square_->IsAdjacentStraight( other ) :
				square_->IsAdjacentOrSelf( other ) );
		}
	private:
		//������������ ��������
		BattleSquare* square_;
		bool straightOnly_;
};





#endif
