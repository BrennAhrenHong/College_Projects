void setup() {
  // put your setup code here, to run once:
  pinMode(13,OUTPUT);
  pinMode(2,INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

   int digitalVal = digitalRead(2);

  if(digitalVal == LOW) //sound is low  
    digitalWrite(13,LOW);

   else
   {
    digitalWrite(13,HIGH);
    delay(1000);
   }
    
}
