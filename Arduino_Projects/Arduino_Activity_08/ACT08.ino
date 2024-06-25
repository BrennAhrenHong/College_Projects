//Constants
const int buttonPin_Azero = A0;
const int buttonPin_Aone = A1;

//Variables
int a = 3;//2
int b = 13;//3
int c = 8;//4
int d = 6;//5
int e = 5;//6
int f = 4;//7
int g = 9;//8
int dp = 7;//9

int d4 = 10;//10
int d3 = 12;//11
int d2 = 11;//12
int d1 = 2;//13

int counter = 0;

int buttonAzeroState = 0;
int buttonAoneState = 0;
//Array
const int myPins[] = {a,b,c,d,e,f,g,dp,d4,d3,d2,d1};

void setup() {
  // put your setup code here, to run once:

  //set all the pins of the LED display as output
  pinMode(d1, OUTPUT);
  pinMode(d2, OUTPUT);
  pinMode(d3, OUTPUT);
  pinMode(d4, OUTPUT);
  pinMode(a, OUTPUT);
  pinMode(b, OUTPUT);
  pinMode(c, OUTPUT);
  pinMode(d, OUTPUT);
  pinMode(e, OUTPUT);
  pinMode(f, OUTPUT);
  pinMode(g, OUTPUT);
  pinMode(dp, OUTPUT);

  pinMode(A0, INPUT);
  pinMode(A1, INPUT);

  //Set to 0
  digital_0();
  
  digitalWrite(d1, LOW);
  digitalWrite(d2, LOW);
  digitalWrite(d3, LOW);
  digitalWrite(d4, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  //set 1st digit


  buttonAzeroState = digitalRead(buttonPin_Azero);
  buttonAoneState = digitalRead(buttonPin_Aone);

  if(buttonAzeroState == HIGH)
  {
    while(counter < 10)
      {
        switch(counter)
        {
          case 0:
            digital_0();
            break;        
          case 1:
            digital_1();
            break;
          case 2:
            digital_2();
            break;      
          case 3:
            digital_3();
            break;        
          case 4:
            digital_4();
            break;
          case 5:
            digital_5();
            break;        
          case 6:
            digital_6();
            break;        
          case 7:
            digital_7();
            break;          
          case 8:
            digital_8();
            break;        
          case 9:
            digital_9();
            break;        
            
          default:
            break;
          }
      counter++;
      delay(500); 
      }
  }

    if(buttonAoneState == HIGH)
    {
    while(counter > -1)
      {
        switch(counter)
        {
          case 0:
            digital_0();
            break;        
          case 1:
            digital_1();
            break;
          case 2:
            digital_2();
            break;      
          case 3:
            digital_3();
            break;        
          case 4:
            digital_4();
            break;
          case 5:
            digital_5();
            break;        
          case 6:
            digital_6();
            break;        
          case 7:
            digital_7();
            break;          
          case 8:
            digital_8();
            break;        
          case 9:
            digital_9();
            break;        
            
          default:
            break;
         }
      counter--;
      delay(500); 
    }
    
  }

}

void digital_0(void) //display 0 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,LOW);
}

void digital_1(void) //display 1 to the 7-segment
{
  digitalWrite(a,LOW);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,LOW);
}

void digital_2(void) //display 2 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,LOW);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,LOW);
  digitalWrite(g,HIGH);
}

void digital_3(void) //display 3 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,HIGH);
}

void digital_4(void) //display 4 to the 7-segment
{
  digitalWrite(a,LOW);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_5(void) //display 5 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,LOW);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,LOW);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_6(void) //display 6 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,LOW);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_7(void) //display 7 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,LOW);
}

void digital_8(void) //display 8 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_9(void) //display 9 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_A(void) //display A to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_b(void) //display B to the 7-segment
{
  digitalWrite(a,LOW);
  digitalWrite(b,LOW);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_C(void) //display C to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,LOW);
  digitalWrite(c,LOW);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,LOW);
}

void digital_d(void) //display D to the 7-segment
{
  digitalWrite(a,LOW);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,LOW);
  digitalWrite(g,HIGH);
}

void digital_E(void) //display E to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,LOW);
  digitalWrite(c,LOW);
  digitalWrite(dp,LOW);
  digitalWrite(d,HIGH);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void digital_F(void) //display F to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,LOW);
  digitalWrite(c,LOW);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,HIGH);
  digitalWrite(f,HIGH);
  digitalWrite(g,HIGH);
}

void dp_display()
{
  digitalWrite(a,LOW);
  digitalWrite(b,LOW);
  digitalWrite(c,LOW);
  digitalWrite(dp,LOW);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,LOW);
}
