#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <ctype.h>


#define MAX_MAHASISWA 5
char namaMahasiswa[MAX_MAHASISWA][50];
float nilaiTugas[MAX_MAHASISWA];
float nilaiUTS[MAX_MAHASISWA];
float nilaiUAS[MAX_MAHASISWA];
char status[MAX_MAHASISWA][15];
int z;
void printRankedMhs(float finalScores[], char status[][15], int n, int sortingOrder) {
    // Create a temporary array to store the indices of students
    int indices[MAX_MAHASISWA];
    int i, j;
    for (i = 0; i < n; i++) {
        indices[i] = i; // Initialize indices with the indices of students
    }

    // Bubble sort the indices array based on final scores or names
    for (i = 0; i < n - 1; i++) {
        for (j = 0; j < n - i - 1; j++) {
            int currIndex = indices[j];
            int nextIndex = indices[j + 1];

            // Compare names if sorting by names (sortingOrder == 1)
            // Use strcmp for string comparison
            if ((sortingOrder == 1 && strcmp(namaMahasiswa[currIndex], namaMahasiswa[nextIndex]) > 0) ||
                // Compare final scores if sorting by scores (sortingOrder == 2)
                (sortingOrder == 2 && finalScores[currIndex] < finalScores[nextIndex])) {
                // Swap indices
                int tempIndex = indices[j];
                indices[j] = indices[j + 1];
                indices[j + 1] = tempIndex;
            }
        }
    }

			// Print the sorted ranked students
	printf("Rank | Name         | Final Score | Status\n");
	printf("-----------------------------------------\n");
	if (sortingOrder == 1) {
	    for (i = 0; i < n; i++) {
	        int index = indices[i];
	        if (strcmp(namaMahasiswa[index], "") != 0) {
	            printf("%-4d | %-12s | %-8.2f | %s\n", i-2, namaMahasiswa[index], finalScores[index], status[index]);
	        }
	    }
	} else {
	    for (i = 0; i < n; i++) {
	        int index = indices[i];
	        if (strcmp(namaMahasiswa[index], "") != 0) {
	            printf("%-4d | %-12s | %-8.2f | %s\n", i+1, namaMahasiswa[index], finalScores[index], status[index]);
	        }
	    }
	}

}


int searchMahasiswa(char searchName[]) {
    int i;
    char lowercaseSearchName[50];
    for (i = 0; searchName[i]; i++) {
        lowercaseSearchName[i] = tolower(searchName[i]); // Convert each character to lowercase
    }
    lowercaseSearchName[i] = '\0'; // Null terminate the lowercase string

    for (i = 0; i < MAX_MAHASISWA; i++) {
        char lowercaseNamaMahasiswa[50];
        int j;
        for (j = 0; namaMahasiswa[i][j]; j++) {
            lowercaseNamaMahasiswa[j] = tolower(namaMahasiswa[i][j]); // Convert each character of the name to lowercase
        }
        lowercaseNamaMahasiswa[j] = '\0'; // Null terminate the lowercase string

        if (strcmp(lowercaseSearchName, lowercaseNamaMahasiswa) == 0) {
            return i; // Return the index if the names match
        }
    }
    return -1; // Return -1 if no match is found
}
bool searchByScoreRange(float minScore, float maxScore, float nilaiAkhir[]) {
    bool found = false;
    int i;
    printf("Students within the score range %.2f - %.2f:\n", minScore, maxScore);
    for (i = 0; i < MAX_MAHASISWA; i++) {
        if (nilaiAkhir[i] >= minScore && nilaiAkhir[i] <= maxScore) {
            printf("Nama: %-20s | Nilai Akhir: %.2f\n", namaMahasiswa[i], nilaiAkhir[i]);
            found = true;
        }
    }
    if (!found) {
        printf("No students found within the specified score range.\n");
    }
    return found;
}

bool searchAndPrint(float nilaiAkhir[]) {
    float minScore, maxScore;
    printf("Enter the score range to search for (e.g., 70 85): ");
    if (scanf("%f %f", &minScore, &maxScore) != 2) {
        printf("Invalid input. Please enter two numeric values.\n");
        return false;
    }

    // Ensure minScore is less than or equal to maxScore
    if (minScore > maxScore) {
        float temp = minScore;
        minScore = maxScore;
        maxScore = temp;
    }

    return searchByScoreRange(minScore, maxScore, nilaiAkhir);
}

void editMahasiswa(int index) {
    printf("Name: %s\n", namaMahasiswa[index]);
    printf("Nilai Tugas: %.2f\n", nilaiTugas[index]);
    printf("Nilai UTS: %.2f\n", nilaiUTS[index]);
    printf("Nilai UAS: %.2f\n", nilaiUAS[index]);

    printf("\nEdit Options:\n");
    printf("1. Change Name\n");
    printf("2. Change Nilai Tugas\n");
    printf("3. Change Nilai UTS\n");
    printf("4. Change Nilai UAS\n");
    printf("5. Remove this student\n");
    printf("0. Cancel\n");

    printf("Enter your choice: ");
    int choice;
    scanf("%d", &choice);

    switch (choice) {
        case 1:
            printf("Enter new name: ");
            scanf("%s", namaMahasiswa[index]);
            break;
        case 2:
            printf("Enter new Nilai Tugas: ");
            scanf("%f", &nilaiTugas[index]);
            break;
        case 3:
            printf("Enter new Nilai UTS: ");
            scanf("%f", &nilaiUTS[index]);
            break;
        case 4:
            printf("Enter new Nilai UAS: ");
            scanf("%f", &nilaiUAS[index]);
            break;
        case 5:
            // Removing the student by shifting all data after the index one position to the left
            for (z = index; z < MAX_MAHASISWA - 1; ++z) {
                strcpy(namaMahasiswa[z], namaMahasiswa[z + 1]);
                nilaiTugas[z] = nilaiTugas[z + 1];
                nilaiUTS[z] = nilaiUTS[z + 1];
                nilaiUAS[z] = nilaiUAS[z + 1];
            }
            strcpy(namaMahasiswa[MAX_MAHASISWA - 1], "");
            nilaiTugas[MAX_MAHASISWA - 1] = 0;
            nilaiUTS[MAX_MAHASISWA - 1] = 0;
            nilaiUAS[MAX_MAHASISWA - 1] = 0;
            printf("Student removed successfully.\n");
            break;
        case 0:
            printf("Canceled.\n");
            break;
        default:
            printf("Invalid choice.\n");
            break;
    }
}

bool searchByStatus(int choice, float nilaiAkhir[]) {
    bool found = false;
    int i;
    if (choice == 1) {
        printf("Mahasiswa with 'Lulus' status:\n");
        for (i = 0; i < MAX_MAHASISWA; i++) {
            if (nilaiAkhir[i] >= 60) {
                printf("Nama: %-20s | Status: Lulus\n", namaMahasiswa[i], status[i]);
                found = true;
            }
        }
    } else {
        printf("Mahasiswa with status other than 'Lulus':\n");
        for (i = 0; i < MAX_MAHASISWA; i++) {
            if (nilaiAkhir[i] < 60) {
                printf("Nama: %-20s | Status: Tidak Lulus\n", namaMahasiswa[i], status[i]);
                found = true;
            }
        }
    }
    if (!found) {
        printf("No Mahasiswa found with the specified status.\n");
    }
    return found;
}


bool searchAndEdit() {
    char searchName[50];
    printf("Enter the name to search: ");
    scanf("%s", searchName);
    int index = searchMahasiswa(searchName);
    if (index != -1) {
        editMahasiswa(index);
        return true;
    } else {
        printf("Name not found.\n");
        return false;
    }
}

