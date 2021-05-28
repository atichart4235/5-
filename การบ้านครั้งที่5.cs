using System;
namespace ConsoleApp61
    {
        class Program
        {
            struct S
            {
            public String ReadImageDataFromFile;
            public String WriteExpandedDataArray;

            }
            static void Main(string[] args)
            {
                Console.Write("Input image data address : ");
                string imagedata = Console.ReadLine();
                double[,] imagedataarray = ReadImageDataFromFile(imagedata);

                Console.Write("Input convolution kernel address : ");
                string convolutionkernel = Console.ReadLine();
                ReadImageDataFromFile(convolutionkernel);
                double[,] convolutionarray = ReadImageDataFromFile(convolutionkernel);

                Console.Write("output address : ");
                string outputaddress = Console.ReadLine();

                int expandedarraycollum = imagedataarray.GetLength(0) + convolutionarray.GetLength(0) - 1;
                int expandedarrayrow = imagedataarray.GetLength(1) + convolutionarray.GetLength(1) - 1;

                double[,] expandeddataarray = WriteExpandedDataArray(imagedataarray, expandedarraycollum, expandedarrayrow, imagedataarray.GetLength(0), imagedataarray.GetLength(1), convolutionarray);

                double[,] outputimagedata = convolutionop(expandeddataarray, convolutionarray, imagedataarray.GetLength(0), imagedataarray.GetLength(1));

                writeimagedatatofile(outputaddress, outputimagedata);
            }
            static double[,] WriteExpandedDataArray(double[,] imagedataarray, int ExpandedCollum, int ExpandedRow, int dataarraycollum, int dataarrayrow, int convolutionkernelcollum, int convolutionrow)
            {
                double[,] expandeddataarray = new double[ExpandedCollum, ExpandedRow];
                for (int i = 0; i < ExpandedCollum; i++)
                {
                    for (int j = 0; j < ExpandedRow; j++)
                    {
                        expandeddataarray[i, j] = imagedataarray[(i + (dataarraycollum - 1)) % dataarraycollum, (j + (dataarraycollum - 1)) % dataarrayrow];
                    }
                }
                return expandeddataarray;
            }
            static double[,] convolutionop(double[,] expandeddataarray, double[,] convolutionarray, int dataarraycollum, int dataarrayrow)
            {
                double[,] outputimagearray = new double[dataarraycollum, dataarrayrow];
                for (int i = 0; i < dataarraycollum; i++)
                {
                    for (int j = 0; j < dataarrayrow; j++)
                    {
                        for (int k = 0; k < convolutionarray.GetLength(1); k++)
                        {
                            for (int l = 0; l < convolutionarray.GetLength(1); l++)
                            {
                                outputimagearray[i, j] += expandeddataarray[i + k, j + l] * convolutionarray[k, l];
                            }
                        }
                    }
                }
                return outputimagearray;
            }
    }
}
