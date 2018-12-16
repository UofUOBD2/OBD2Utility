// demo: CAN-BUS Shield, send data
// loovee@seeed.cc

// Code obtained from CAN Bus Shield Library https://github.com/Seeed-Studio/CAN_BUS_Shield
// Modified for the purpose of our simulator (OBD2 Team)

#include <mcp_can.h>
#include <SPI.h>

// the cs pin of the version after v1.1 is default to D9
// v0.9b and v1.0 is default D10
const int SPI_CS_PIN = 10;

MCP_CAN CAN(SPI_CS_PIN);                                  // Set CS pin

void setup()
{
    Serial.begin(115200);

    while (CAN_OK != CAN.begin(CAN_250KBPS))              // init can bus : baudrate = 500k
    {
        Serial.println("CAN BUS Shield init fail");
        Serial.println("Init CAN BUS Shield again");
        delay(100);
    }
    Serial.println("CAN BUS Shield init ok!");
}

unsigned char stmpRPM[8] =   {0x4, 0x41, 0xC, 0x0, 0xA3, 0x0, 0x0, 0x0};
unsigned char stmpSPEED[8] = {0x3, 0x41, 0xD, 0xD, 0x0, 0x0, 0x0, 0x0};
unsigned char stmpTEMP[8] =  {0x3, 0x41, 0x05, 0x83, 0x0, 0x0, 0x0, 0x0};
unsigned char stmpFUEL[8] =  {0x3, 0x41, 0x2F, 0x43, 0x0, 0x0, 0x0, 0x0};

void loop()
{
    
    CAN.sendMsgBuf(0x7E8, 0, 8, stmpRPM);
    Serial.println("Sent RPM");
    delay(500);    
    
    CAN.sendMsgBuf(0x7E8, 0, 8, stmpSPEED);
    Serial.println("Sent SPEED");
    delay(500); 
    
    CAN.sendMsgBuf(0x7E8, 0, 8, stmpTEMP);
    Serial.println("Sent TEMP");
    delay(500);    
    
    CAN.sendMsgBuf(0x7E8, 0, 8, stmpFUEL);
    Serial.println("Sent FUEL");
    delay(500); 
    
    if(stmpRPM[3] > 0x80)
    {
      stmpRPM[3] = 0x00;
    } else {
      stmpRPM[3] += 0x05;  
    }
    
    if(stmpSPEED[3] > 0xE1)
    {
      stmpSPEED[3] = 0x00;
    } else {
      stmpSPEED[3] += 0x05;  
    }
    
    if(stmpTEMP[3] > (0x96 + 0X28))
    {
      stmpTEMP[3] = 0x32;
    } else {
      stmpTEMP[3] += 0x05;  
    }
    
    if(stmpFUEL[3] > 0x64)
    {
      stmpFUEL[3] = 0x00;
    } else {
      stmpFUEL[3] += 0x05;  
    }
    
    delay(1000);

}

// END FILE
