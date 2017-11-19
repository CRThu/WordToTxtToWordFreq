// TxtToWordFreq.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

string ws2s(const wstring& ws)
{
    string curLocale = setlocale(LC_ALL, NULL); // curLocale = "C";  

    setlocale(LC_ALL, "chs");

    const wchar_t* _Source = ws.c_str();
    size_t _Dsize = 2 * ws.size() + 1;
    char *_Dest = new char[_Dsize];
    memset(_Dest, 0, _Dsize);
    wcstombs(_Dest, _Source, _Dsize);
    string result = _Dest;
    delete[]_Dest;

    setlocale(LC_ALL, curLocale.c_str());

    return result;
}

wstring s2ws(const string& s)
{
    setlocale(LC_ALL, "chs");

    const char* _Source = s.c_str();
    size_t _Dsize = s.size() + 1;
    wchar_t *_Dest = new wchar_t[_Dsize];
    wmemset(_Dest, 0, _Dsize);
    mbstowcs(_Dest, _Source, _Dsize);
    wstring result = _Dest;
    delete[]_Dest;

    setlocale(LC_ALL, "C");

    return result;
}

struct freq
{
    wchar_t word;
    int cnt=0;
};

bool BigToSmall(const freq &a, const freq &b)
{
    return a.cnt > b.cnt;
}

int main(int argc,char *argv[])
{
    vector<wstring> DocText;

    wcout.imbue(locale("chs"));

    ifstream inFile(argv[1]);
    //ifstream inFile("temp.txt");
    
    for (; !inFile.eof();)
    {
        string Data;
        inFile >> Data;
        //cout << Data;
        wstring wdata=s2ws(Data);
        DocText.push_back(wdata);
        //wcout << wdata<<endl;
    }
    inFile.close();

    vector<freq> FreqCalc;
    
    for (auto iter : DocText)
    {
        for (int i = 0; i < iter.size(); i++)
        {
            if (iter[i] != ' ')
            {
                bool flag = 0;
                //for (auto iterF : FreqCalc)
                for (int j = 0; j < FreqCalc.size(); j++)
                {
                    if (FreqCalc[j].word == iter[i])
                    {
                        FreqCalc[j].cnt++;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    freq temp;
                    temp.word = iter[i];
                    temp.cnt = 1;
                    FreqCalc.push_back(temp);
                }
            }
        }
        ;
    }

    // order
    sort(FreqCalc.begin(), FreqCalc.end(), BigToSmall);

    wofstream log(argv[2]);
    //wofstream log("log.txt");
    log.imbue(locale("chs"));
    for (int i = 0; i < FreqCalc.size(); i++)
    {
        wcout << FreqCalc[i].word << " " << FreqCalc[i].cnt << endl;
        log << FreqCalc[i].word << " " << FreqCalc[i].cnt << " ";
    }
    log.close();

    //getchar();
    return 0;
}

