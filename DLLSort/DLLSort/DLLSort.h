#define DLLSORT_API __declspec(dllexport) 
extern "C" {
    DLLSORT_API void TestSort(int a[], int length);
}