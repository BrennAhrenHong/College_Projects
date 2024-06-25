int buzzerPin = 12;

void setup() {
  // put your setup code here, to run once:
  pinMode(buzzerPin,OUTPUT);//set buzzerpin as output
}

void loop() {
  // put your main code here, to run repeatedly:
for(int i = 500; i<= 1000; i++)//increase frequency
{
  tone(buzzerPin,i); //generate tone

  delay(5);
}
delay(1000);

for(int i = 1000; i>= 500; i--) //decrease frequency

{
  tone(buzzerPin,i);
  delay(5);
}
delay(1000);
}
