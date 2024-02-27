#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#define MAX_MAHASISWA 5
#define BOBOT_TUGAS 0.2
#define BOBOT_UTS 0.35
#define BOBOT_UAS 0.45
#define NILAI_LULUS 60

#include "searchAndPrint.h"

void inputDataMahasiswa() {
    static int numMahasiswa = 0; // Declared as static to retain its value between function calls
    int i = numMahasiswa; // Start entering data from the current count of students
    for (; i < MAX_MAHASISWA; i++) {
        strcpy(namaMahasiswa[i], ""); // Initialize the name to an empty string
        printf("Mahasiswa ke-%d\n", i + 1);
        printf("Nama: ");
        scanf("%s", namaMahasiswa[i]);

        // Clear remaining characters from the input buffer
        int c;
        while ((c = getchar()) != '\n' && c != EOF);

        printf("Nilai Tugas: ");
        scanf("%f", &nilaiTugas[i]);
        printf("Nilai UTS: ");
        scanf("%f", &nilaiUTS[i]);
        printf("Nilai UAS: ");
        scanf("%f", &nilaiUAS[i]);
        printf("\n");
        numMahasiswa++; // Increment the count of students after each entry
        printf("Input data lagi? (Y/N): ");
        char choice;
        scanf(" %c", &choice);
        if (choice != 'Y' && choice != 'y') {
        	system("cls");
            break; // Stop entering data if the user doesn't want to continue
        }
    }
}



// kalkulasi nilai akhir
void hitungNilaiAkhir(float nilaiAkhir[]) {
	int i;
    for (i = 0; i < MAX_MAHASISWA; i++) {
        nilaiAkhir[i] = nilaiTugas[i] * BOBOT_TUGAS + nilaiUTS[i] * BOBOT_UTS + nilaiUAS[i] * BOBOT_UAS;
    }
}

// penentu status lulus / tidak
void tentukanStatus(float nilaiAkhir[], char status[][15]) {
	int i;
    for (i = 0; i < MAX_MAHASISWA; i++) {
        if (nilaiAkhir[i] >= NILAI_LULUS) {
            strcpy(status[i], "Lulus");
        } else {
            strcpy(status[i], "Tidak Lulus");
        }
    }
}
// fungsi kalkulasi yang akan dipanggil di main / di sort.c
void kalkulasi(int sortingMethod) {
    float nilaiAkhir[MAX_MAHASISWA];
    hitungNilaiAkhir(nilaiAkhir);
    char status[MAX_MAHASISWA][15];
    tentukanStatus(nilaiAkhir, status);
    system("cls");
    switch (sortingMethod) {
        case 1:
            printRankedMhs(nilaiAkhir, status, MAX_MAHASISWA, 1); // Sorting by names in ascending order
            break;
        case 2:
            printRankedMhs(nilaiAkhir, status, MAX_MAHASISWA, 2); // Sorting by final scores in descending order
            break;
        case 3:
            inputDataMahasiswa();
            break;
        case 4:
            printRankedMhs(nilaiAkhir, status, MAX_MAHASISWA, 2); // Sorting by final scores in descending order
            break;
        case 5:
            printRankedMhs(nilaiAkhir, status, MAX_MAHASISWA, 1); // Sorting by names in ascending order
            break;
       case 7:
		    {
		        int choice;
		        printf("Enter 1 to search for Mahasiswa with 'Lulus' status or any other number to search for Mahasiswa with status other than 'Lulus': ");
		        scanf("%d", &choice);
		        searchByStatus(choice, nilaiAkhir);
		        break;
		    }

		case 8:
		{
		    char searchName[50];
		    printf("Enter the name of the student you want to edit: ");
		    scanf("%s", searchName);
		    int index = searchMahasiswa(searchName);
		    if (index != -1) {
		        printf("Student found at rank %d\n", index+1);
		        
		        printf("\n Current Data :\n");
				editMahasiswa(index);
		    } else {
		        printf("Student not found.\n");
		    }
		    break;
		}
		case 9:
			{
			    float minScore, maxScore;
			    printf("Enter the range of the value (from A to B): ");
			    scanf("%f %f", &minScore, &maxScore);
			    searchByScoreRange(minScore, maxScore, nilaiAkhir);
			    break;
			}




        default:
            break;
    }
}

