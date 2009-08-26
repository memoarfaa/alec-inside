#ifndef shipH
#define shipH

// ��� ���������� �������
enum ShipAlign { saHorizontal, saVertical };

// �������
class Ship {
	public:
		/*
		   deckCount - ����� �����;
		   align - ���������� �������
		*/
		Ship( int deckCount, ShipAlign align = saHorizontal ) :
			deckCount_( deckCount ), liveDeckCount_( deckCount ),
			align_( align )  {
		}
		// ����� ����� �������
		int DeckCount() const {
			return deckCount_;
		}
		// ���������� ���������� �������
		ShipAlign GetAlign() const {
			return align_;
		}
		// ������������� ���������� �������
		void SetAlign( ShipAlign align ) {
			align_ = align;
		}
		// ����� ������ ���������� �������� �� ����������
		int Width() const {
			return ( align_ == saHorizontal ? deckCount_ : 1 );
		}
		// ����� ������ ���������� �������� �� ���������
		int Height() const {
			return ( align_ == saVertical ? deckCount_ : 1 );
		}
		// ������� "���" ��� ��������
		bool IsLive() const {
			return liveDeckCount_ > 0;
		}
		// ���������� ������
		void DestroyDeck() {
			--liveDeckCount_;
        }
	private:
		// ������ �������
		int deckCount_;
		// ����� ������
		int liveDeckCount_;
		// ���������� �������
		ShipAlign align_;
		// ����������� �� ���������
		Ship( const Ship& other );
		Ship& operator=( const Ship& );
};
#endif