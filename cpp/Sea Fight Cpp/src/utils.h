#ifndef utilsH
#define utilsH

#include <ctime>
#include <cstdlib>
#include <iostream>
#include <string>

//���������� ��������� ����� � ��������� [lowest,highest]
int RandomRange( int lowest, int highest ) {
	static bool called = false;
	if ( !called ) {
		std::srand((unsigned)std::time(0));
		called = true;
	}
	return lowest+int(((highest-lowest)+1)*std::rand()/(RAND_MAX + 1.0));
}

// ������� ������� ���� T
template<class T> void wipe( T* ptr ) {
	delete ptr;
}

//�������
class Console {
	public:
    	// ��������� � ����������� ����
		template<class T>
		static T Request( const std::string& message ) {
			std::cout << message;
			T res;
			std::cin >> res;
			std::cin.clear();
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			return res;
		}
	private:
		Console() {}
};
#endif
