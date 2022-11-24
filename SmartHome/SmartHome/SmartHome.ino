#include <deprecated.h>
#include <MFRC522.h>
#include <MFRC522Extended.h>
#include <require_cpp11.h>

#include <RFID.h>
#include <SPI.h>
#include <Servo.h>

#define SS_PIN 10
#define RST_PIN 9
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance.

int rfid=8;
int Motor=4;

Servo myServo;

 
void setup() 
{
  Serial.begin(9600);   // Initiate a serial communication
  SPI.begin();      // Initiate  SPI bus
  mfrc522.PCD_Init();   // Initiate MFRC522
  pinMode(rfid,OUTPUT);
  myServo.attach(3);
  pinMode(Motor,INPUT);
  myServo.write(0);

  
}
void loop() 
{
  Serial.begin(9600);   // Initiate a serial communication
  SPI.begin();      // Initiate  SPI bus
  mfrc522.PCD_Init();   // Initiate MFRC522
  
  // Look for new cards
  //Show UID on serial monitor
  Serial.println("UID tag : ");
  String content= "";
  byte letter;
  if ( mfrc522.PICC_IsNewCardPresent()& mfrc522.PICC_ReadCardSerial()) 
  {
      for (byte i = 0; i < mfrc522.uid.size; i++) 
      {
         Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
         Serial.print(mfrc522.uid.uidByte[i], HEX);
         content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
         content.concat(String(mfrc522.uid.uidByte[i], HEX));
      }
  }
  mfrc522.PICC_HaltA();
  mfrc522.PCD_StopCrypto1();
  content.toUpperCase();
  if (content.substring(1) == "E9 D4 6B 8E" || content.substring(1) == "77 74 8A 5F") //change here the UID of the card/cards that you want to give access
  {
    Serial.println("araf");
    digitalWrite(rfid,HIGH);
    Serial.print(digitalRead(rfid));
   
  }
  else
  {
    digitalWrite(rfid,LOW);
     Serial.print(digitalRead(rfid));
   }
  
  Serial.println();
  Serial.println(digitalRead(Motor));
  if(digitalRead(Motor)==HIGH)
  {
  for(int i=0;i<=90;i++)
  {
    myServo.write(i);
    delay(30);
  }
  delay(15000);
  for(int i=90;i>=0;i--)
  {
    myServo.write(i);
    delay(20);
  }
  
  }
  digitalWrite(rfid,LOW);
  }

  

 

  
  

 
   
  
  
