float val = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(13,OUTPUT); //set built-in LED as output
}

void loop() {
  // put your main code here, to run repeatedly:
  val = analogRead(A0); //read value of LDR

  if(val < 750) // not enough light for LDR

    digitalWrite(13,LOW);
  else //Enough light for LDR
    digitalWrite(13,HIGH);
}
