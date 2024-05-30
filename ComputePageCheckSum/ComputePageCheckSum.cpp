//***CODE***//
#include <stdio.h>
#include <stdlib.h>
#define seed 15 //Initial seed(for first sector)
#define CHAR_BIT 8 
//***PROTOTYPES***//
unsigned int page_checksum(int page_id, unsigned int *ondisk,char*);
unsigned int rol(unsigned int value, unsigned int rotation);
int main(int argc, char* argv[]) {
    unsigned int computed_checksum; //Var to retrieve calculated checksum
    unsigned int ondisk_checksum; //Var to retrieve checksum on disk
    int pagenumber;

    char str[100];
    printf("Enter full path of mdf: ");
    fgets(str, sizeof(str), stdin);
    printf("You entered: %s\n", str);
    printf("Enter page number:");
    scanf_s("%d", &pagenumber);
    printf("You entered: %d\n", pagenumber);

    computed_checksum = page_checksum(152, &ondisk_checksum,str); //page_checksum call to retrieve stored and calculated checksum for page 152
    //***PRINTS***//
    printf("Calculated checksum: 0x%08x\n", computed_checksum);
    printf("On disk checksum: 0x%08x\n", ondisk_checksum);
    scanf_s("%d", &pagenumber);
}
unsigned int page_checksum(int page_id, unsigned int* ondisk, char* mdfpath) {
    FILE* fileptr;
    unsigned int i;
    unsigned int j;
    unsigned int checksum;
    unsigned int overall;
    unsigned int* pagebuf[16][128]; //A pointer to describe 2d array [sector][element]
    errno_t t = fopen_s(&fileptr,mdfpath, "r+b"); //Open dummy data file for binary read
    

    fseek(fileptr, page_id * 8192, SEEK_SET); //Calculate page address on data file and points to it
    fread(pagebuf, 4, 2048, fileptr); //Read page buffer
    fclose(fileptr);
    checksum = 0;
    overall = 0;
    *ondisk = *pagebuf[0][15]; //This means that torn bits is stored on first sector in 15th element, Internals researches understand this
    pagebuf[0][15] = 0x00000000; //Fill checksum field with zeroes (this field will be discarded in algorithm)

    for (i = 0; i < 16; i++) //Loop through sectors
    {
        overall = 0; //Reset overall sum for sectors
        for (j = 0; j < 128; j++) //Loop through elements in sector i
        {
            overall = overall ^ (unsigned int)pagebuf[i][j]; //XOR operation between sector i elements
        }
        checksum = checksum ^ rol(overall, seed - i); //Current checksum is overall for sector i circular shifted by seed (15 - i)
    }
    return checksum; //Gets checksum
}
unsigned int rol(unsigned int value, unsigned int rotation) {
    return (value) << (rotation) | (value) >> (sizeof(int) * CHAR_BIT - rotation) & ((1 << rotation) - 1);
}