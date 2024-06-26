  const int a=9; //a of 7-segment attach to digital pin 9
  const int b=8; //b of 7-segment attach to digital pin 8
  const int c=7; //c of 7-segment attach to digital pin 7
  const int d=6; //c of 7-segment attach to digital pin 6
  const int e=5; //d of 7-segment attach to digital pin 5
  const int f=4; //e of 7                 -segment attach to digital pin 4
  const int g=3; //f of 7-segment attach to digital pin 3
  const int dp=2; //g of 7-segment attach to digital pin 2
  
void setup() {
  // put your setup code here, to run once:
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(8,OUTPUT);
  pinMode(9,OUTPUT);
    
}

void loop() {
  // put your main code here, to run repeatedly:
  digital_7();
  delay(1000);
  dp_display();
  delay(1000);
}

void digital_7(void) //display 7 to the 7-segment
{
  digitalWrite(a,HIGH);
  digitalWrite(b,HIGH);
  digitalWrite(c,HIGH);
  digitalWrite(dp,HIGH);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,LOW);
}

void dp_display()
{
  digitalWrite(a,LOW);
  digitalWrite(b,LOW);
  digitalWrite(c,LOW);
  digitalWrite(dp,HIGH);
  digitalWrite(d,LOW);
  digitalWrite(e,LOW);
  digitalWrite(f,LOW);
  digitalWrite(g,LOW);
}
