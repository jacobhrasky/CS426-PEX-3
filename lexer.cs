/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;
using System.IO;
using CS426.node;

namespace CS426.lexer {

internal class PushbackReader {
  private TextReader reader;
  private Stack stack = new Stack ();


  internal PushbackReader (TextReader reader)
  {
    this.reader = reader;
  }

  internal int Peek ()
  {
    if ( stack.Count > 0 ) return (int)stack.Peek();
    return reader.Peek();
  }

  internal int Read ()
  {
    if ( stack.Count > 0 ) return (int)stack.Pop();
    return reader.Read();
  }

  internal void Unread (int v)
  {
    stack.Push (v);
  }
}

public class LexerException : ApplicationException
{
    public LexerException(String message) : base (message)
    {
    }
}

public class Lexer
{
    protected Token token;
    protected State currentState = State.INITIAL;

    private PushbackReader input;
    private int line;
    private int pos;
    private bool cr;
    private bool eof;
    private StringBuilder text = new StringBuilder();

    protected virtual void Filter()
    {
    }

    public Lexer(TextReader input)
    {
        this.input = new PushbackReader(input);
    }

    public virtual Token Peek()
    {
        while(token == null)
        {
            token = GetToken();
            Filter();
        }

        return token;
    }

    public virtual Token Next()
    {
        while(token == null)
        {
            token = GetToken();
            Filter();
        }

        Token result = token;
        token = null;
        return result;
    }

    protected virtual Token GetToken()
    {
        int dfa_state = 0;

        int start_pos = pos;
        int start_line = line;

        int accept_state = -1;
        int accept_token = -1;
        int accept_length = -1;
        int accept_pos = -1;
        int accept_line = -1;

        int[][][] gotoTable = Lexer.gotoTable[currentState.id()];
        int[] accept = Lexer.accept[currentState.id()];
        text.Length = 0;

        while(true)
        {
            int c = GetChar();

            if(c != -1)
            {
                switch(c)
                {
                case 10:
                    if(cr)
                    {
                        cr = false;
                    }
                    else
                    {
                        line++;
                        pos = 0;
                    }
                    break;
                case 13:
                    line++;
                    pos = 0;
                    cr = true;
                    break;
                default:
                    pos++;
                    cr = false;
                    break;
                };

                text.Append((char) c);
                do
                {
                    int oldState = (dfa_state < -1) ? (-2 -dfa_state) : dfa_state;

                    dfa_state = -1;

                    int[][] tmp1 =  gotoTable[oldState];
                    int low = 0;
                    int high = tmp1.Length - 1;

                    while(low <= high)
                    {
                        int middle = (low + high) / 2;
                        int[] tmp2 = tmp1[middle];

                        if(c < tmp2[0])
                        {
                            high = middle - 1;
                        }
                        else if(c > tmp2[1])
                        {
                            low = middle + 1;
                        }
                        else
                        {
                            dfa_state = tmp2[2];
                            break;
                        }
                    }
                }while(dfa_state < -1);
            }
            else
            {
                dfa_state = -1;
            }

            if(dfa_state >= 0)
            {
                if(accept[dfa_state] != -1)
                {
                    accept_state = dfa_state;
                    accept_token = accept[dfa_state];
                    accept_length = text.Length;
                    accept_pos = pos;
                    accept_line = line;
                }
            }
            else
            {
                if(accept_state != -1)
                {
                    switch(accept_token)
                    {
                    case 0:
                        {
                            Token token = New0(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 1:
                        {
                            Token token = New1(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 2:
                        {
                            Token token = New2(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 3:
                        {
                            Token token = New3(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 4:
                        {
                            Token token = New4(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 5:
                        {
                            Token token = New5(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 6:
                        {
                            Token token = New6(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 7:
                        {
                            Token token = New7(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 8:
                        {
                            Token token = New8(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 9:
                        {
                            Token token = New9(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 10:
                        {
                            Token token = New10(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 11:
                        {
                            Token token = New11(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 12:
                        {
                            Token token = New12(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 13:
                        {
                            Token token = New13(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 14:
                        {
                            Token token = New14(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 15:
                        {
                            Token token = New15(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 16:
                        {
                            Token token = New16(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 17:
                        {
                            Token token = New17(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 18:
                        {
                            Token token = New18(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 19:
                        {
                            Token token = New19(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 20:
                        {
                            Token token = New20(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 21:
                        {
                            Token token = New21(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 22:
                        {
                            Token token = New22(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 23:
                        {
                            Token token = New23(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 24:
                        {
                            Token token = New24(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 25:
                        {
                            Token token = New25(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 26:
                        {
                            Token token = New26(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 27:
                        {
                            Token token = New27(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 28:
                        {
                            Token token = New28(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 29:
                        {
                            Token token = New29(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 30:
                        {
                            Token token = New30(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 31:
                        {
                            Token token = New31(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    case 32:
                        {
                            Token token = New32(
                                GetText(accept_length),
                                start_line + 1,
                                start_pos + 1);
                            PushBack(accept_length);
                            pos = accept_pos;
                            line = accept_line;
                            return token;
                        }
                    }
                }
                else
                {
                    if(text.Length > 0)
                    {
                        throw new LexerException(
                            "[" + (start_line + 1) + "," + (start_pos + 1) + "]" +
                            " Unknown token: " + text);
                    }
                    else
                    {
                        EOF token = new EOF(
                            start_line + 1,
                            start_pos + 1);
                        return token;
                    }
                }
            }
        }
    }

    private Token New0(String text, int line, int pos) { return new TAssign(text, line, pos); }
    private Token New1(String text, int line, int pos) { return new TPlusSign(text, line, pos); }
    private Token New2(String text, int line, int pos) { return new TStar(text, line, pos); }
    private Token New3(String text, int line, int pos) { return new TSemiColon(text, line, pos); }
    private Token New4(String text, int line, int pos) { return new TLParen(text, line, pos); }
    private Token New5(String text, int line, int pos) { return new TRParen(text, line, pos); }
    private Token New6(String text, int line, int pos) { return new TMinusSign(text, line, pos); }
    private Token New7(String text, int line, int pos) { return new TSlash(text, line, pos); }
    private Token New8(String text, int line, int pos) { return new TLtSign(text, line, pos); }
    private Token New9(String text, int line, int pos) { return new TLeqSign(text, line, pos); }
    private Token New10(String text, int line, int pos) { return new TGtSign(text, line, pos); }
    private Token New11(String text, int line, int pos) { return new TGeqSign(text, line, pos); }
    private Token New12(String text, int line, int pos) { return new TEqSign(text, line, pos); }
    private Token New13(String text, int line, int pos) { return new TNeqSign(text, line, pos); }
    private Token New14(String text, int line, int pos) { return new TNotSign(text, line, pos); }
    private Token New15(String text, int line, int pos) { return new TAndSign(text, line, pos); }
    private Token New16(String text, int line, int pos) { return new TOrSign(text, line, pos); }
    private Token New17(String text, int line, int pos) { return new TLBrace(text, line, pos); }
    private Token New18(String text, int line, int pos) { return new TRBrace(text, line, pos); }
    private Token New19(String text, int line, int pos) { return new TComma(text, line, pos); }
    private Token New20(String text, int line, int pos) { return new TRwType(text, line, pos); }
    private Token New21(String text, int line, int pos) { return new TRwIf(text, line, pos); }
    private Token New22(String text, int line, int pos) { return new TRwElse(text, line, pos); }
    private Token New23(String text, int line, int pos) { return new TRwWhile(text, line, pos); }
    private Token New24(String text, int line, int pos) { return new TRwConst(text, line, pos); }
    private Token New25(String text, int line, int pos) { return new TRwFunction(text, line, pos); }
    private Token New26(String text, int line, int pos) { return new TRwMain(text, line, pos); }
    private Token New27(String text, int line, int pos) { return new TLitInteger(text, line, pos); }
    private Token New28(String text, int line, int pos) { return new TLitFloat(text, line, pos); }
    private Token New29(String text, int line, int pos) { return new TLitStr(text, line, pos); }
    private Token New30(String text, int line, int pos) { return new TId(text, line, pos); }
    private Token New31(String text, int line, int pos) { return new TComment(text, line, pos); }
    private Token New32(String text, int line, int pos) { return new TWhitespace(text, line, pos); }

    private int GetChar()
    {
        if(eof)
        {
            return -1;
        }

        int result = input.Read();

        if(result == -1)
        {
            eof = true;
        }

        return result;
    }

    private void PushBack(int acceptLength)
    {
        int length = text.Length;
        for(int i = length - 1; i >= acceptLength; i--)
        {
            eof = false;

            input.Unread(text[i]);
        }
    }


    protected virtual void Unread(Token token)
    {
        String text = token.Text;
        int length = text.Length;

        for(int i = length - 1; i >= 0; i--)
        {
            eof = false;

            input.Unread(text[i]);
        }

        pos = token.Pos - 1;
        line = token.Line - 1;
    }

    private string GetText(int acceptLength)
    {
        StringBuilder s = new StringBuilder(acceptLength);
        for(int i = 0; i < acceptLength; i++)
        {
            s.Append(text[i]);
        }

        return s.ToString();
    }

    private static int[][][][] gotoTable = {
      new int[][][] {
        new int[][] {
          new int[] {9, 9, 1},
          new int[] {10, 10, 2},
          new int[] {13, 13, 3},
          new int[] {32, 32, 4},
          new int[] {33, 33, 5},
          new int[] {34, 34, 6},
          new int[] {38, 38, 7},
          new int[] {40, 40, 8},
          new int[] {41, 41, 9},
          new int[] {42, 42, 10},
          new int[] {43, 43, 11},
          new int[] {44, 44, 12},
          new int[] {45, 45, 13},
          new int[] {47, 47, 14},
          new int[] {48, 48, 15},
          new int[] {49, 57, 16},
          new int[] {58, 58, 17},
          new int[] {59, 59, 18},
          new int[] {60, 60, 19},
          new int[] {61, 61, 20},
          new int[] {62, 62, 21},
          new int[] {65, 90, 22},
          new int[] {95, 95, 23},
          new int[] {97, 98, 22},
          new int[] {99, 99, 24},
          new int[] {100, 100, 22},
          new int[] {101, 101, 25},
          new int[] {102, 102, 26},
          new int[] {103, 104, 22},
          new int[] {105, 105, 27},
          new int[] {106, 108, 22},
          new int[] {109, 109, 28},
          new int[] {110, 114, 22},
          new int[] {115, 115, 29},
          new int[] {116, 118, 22},
          new int[] {119, 119, 30},
          new int[] {120, 122, 22},
          new int[] {123, 123, 31},
          new int[] {124, 124, 32},
          new int[] {125, 125, 33},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {9, 32, -2},
        },
        new int[][] {
          new int[] {61, 61, 34},
        },
        new int[][] {
          new int[] {0, 9, 35},
          new int[] {11, 12, 35},
          new int[] {14, 33, 35},
          new int[] {34, 34, 36},
          new int[] {35, 91, 35},
          new int[] {92, 92, 37},
          new int[] {93, 65535, 35},
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
          new int[] {47, 47, 38},
        },
        new int[][] {
          new int[] {46, 46, 39},
        },
        new int[][] {
          new int[] {46, 46, 40},
          new int[] {48, 57, 41},
        },
        new int[][] {
          new int[] {61, 61, 42},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {61, 61, 43},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {61, 61, 44},
        },
        new int[][] {
          new int[] {48, 57, 45},
          new int[] {65, 90, 46},
          new int[] {95, 95, 47},
          new int[] {97, 122, 46},
        },
        new int[][] {
          new int[] {48, 57, 48},
          new int[] {65, 90, 49},
          new int[] {97, 122, 49},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 110, 46},
          new int[] {111, 111, 50},
          new int[] {112, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 107, 46},
          new int[] {108, 108, 51},
          new int[] {109, 122, 46},
        },
        new int[][] {
          new int[] {48, 107, -27},
          new int[] {108, 108, 52},
          new int[] {109, 116, 46},
          new int[] {117, 117, 53},
          new int[] {118, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 101, 46},
          new int[] {102, 102, 54},
          new int[] {103, 109, 46},
          new int[] {110, 110, 55},
          new int[] {111, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 97, 56},
          new int[] {98, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 115, 46},
          new int[] {116, 116, 57},
          new int[] {117, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 103, 46},
          new int[] {104, 104, 58},
          new int[] {105, 122, 46},
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
          new int[] {0, 65535, -8},
        },
        new int[][] {
        },
        new int[][] {
          new int[] {34, 34, 59},
          new int[] {92, 92, 60},
        },
        new int[][] {
          new int[] {0, 9, 61},
          new int[] {11, 12, 61},
          new int[] {14, 65535, 61},
        },
        new int[][] {
          new int[] {48, 48, 62},
          new int[] {49, 57, 63},
        },
        new int[][] {
          new int[] {48, 48, 64},
          new int[] {49, 57, 65},
        },
        new int[][] {
          new int[] {46, 46, 39},
          new int[] {48, 57, 41},
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 90, -24},
          new int[] {97, 122, 46},
        },
        new int[][] {
          new int[] {48, 90, -25},
          new int[] {95, 95, 66},
          new int[] {97, 122, 49},
        },
        new int[][] {
          new int[] {48, 122, -50},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 109, 46},
          new int[] {110, 110, 67},
          new int[] {111, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 114, 46},
          new int[] {115, 115, 68},
          new int[] {116, 122, 46},
        },
        new int[][] {
          new int[] {48, 110, -26},
          new int[] {111, 111, 69},
          new int[] {112, 122, 46},
        },
        new int[][] {
          new int[] {48, 109, -52},
          new int[] {110, 110, 70},
          new int[] {111, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 115, -31},
          new int[] {116, 116, 71},
          new int[] {117, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 104, 46},
          new int[] {105, 105, 72},
          new int[] {106, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 113, 46},
          new int[] {114, 114, 73},
          new int[] {115, 122, 46},
        },
        new int[][] {
          new int[] {48, 104, -58},
          new int[] {105, 105, 74},
          new int[] {106, 122, 46},
        },
        new int[][] {
          new int[] {0, 65535, -8},
        },
        new int[][] {
          new int[] {0, 65535, -8},
        },
        new int[][] {
          new int[] {0, 65535, -40},
        },
        new int[][] {
          new int[] {48, 48, 75},
          new int[] {49, 57, 63},
        },
        new int[][] {
          new int[] {48, 57, -64},
        },
        new int[][] {
          new int[] {48, 48, 76},
          new int[] {49, 57, 65},
          new int[] {101, 101, 77},
        },
        new int[][] {
          new int[] {48, 101, -66},
        },
        new int[][] {
          new int[] {48, 122, -25},
        },
        new int[][] {
          new int[] {48, 114, -53},
          new int[] {115, 115, 78},
          new int[] {116, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 100, 46},
          new int[] {101, 101, 79},
          new int[] {102, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 97, 80},
          new int[] {98, 122, 46},
        },
        new int[][] {
          new int[] {48, 95, -24},
          new int[] {97, 98, 46},
          new int[] {99, 99, 81},
          new int[] {100, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 109, -52},
          new int[] {110, 110, 82},
          new int[] {111, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 107, -27},
          new int[] {108, 108, 83},
          new int[] {109, 122, 46},
        },
        new int[][] {
          new int[] {48, 57, -64},
        },
        new int[][] {
          new int[] {48, 57, -66},
        },
        new int[][] {
          new int[] {45, 45, 84},
          new int[] {49, 57, 85},
        },
        new int[][] {
          new int[] {48, 115, -31},
          new int[] {116, 116, 86},
          new int[] {117, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 115, -31},
          new int[] {116, 116, 87},
          new int[] {117, 122, 46},
        },
        new int[][] {
          new int[] {48, 115, -31},
          new int[] {116, 116, 88},
          new int[] {117, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 100, -70},
          new int[] {101, 101, 89},
          new int[] {102, 122, 46},
        },
        new int[][] {
          new int[] {49, 57, 85},
        },
        new int[][] {
          new int[] {48, 57, 90},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 104, -58},
          new int[] {105, 105, 91},
          new int[] {106, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
        new int[][] {
          new int[] {48, 57, 90},
        },
        new int[][] {
          new int[] {48, 110, -26},
          new int[] {111, 111, 92},
          new int[] {112, 122, 46},
        },
        new int[][] {
          new int[] {48, 109, -52},
          new int[] {110, 110, 93},
          new int[] {111, 122, 46},
        },
        new int[][] {
          new int[] {48, 122, -24},
        },
      },
    };

    private static int[][] accept = {
      new int[] {
        -1, 32, 32, 32, 32, 14, -1, 15, 4, 5, 2, 1, 19, 6, 7, 27, 
        27, -1, 3, 8, 12, 10, 30, 30, 30, 30, 30, 30, 30, 30, 30, 17, 
        16, 18, 13, -1, 29, -1, 31, -1, -1, 27, 0, 9, 11, 30, 30, 30, 
        30, 30, 30, 30, 30, 30, 21, 30, 30, 30, 30, -1, -1, 31, 28, 28, 
        28, 28, 30, 30, 30, 30, 30, 20, 30, 20, 30, -1, -1, -1, 30, 22, 
        30, 30, 26, 30, -1, 28, 24, 20, 30, 23, 28, 30, 30, 25, 
      },
    };

    public class State
    {
        public static State INITIAL = new State(0);

        private int _id;

        private State(int _id)
        {
            this._id = _id;
        }

        public int id()
        {
            return _id;
        }
    }
}
}