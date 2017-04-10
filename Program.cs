using System;
using System.Linq;

class HappyNumbers
{
    public int halflength; //!< Half length of happy number
    public int biggest;    //!< Biggest happy nymber
    public int lastnumber; //!< Last founded happy number

    /*!
     * \brief Constructor
     * \details Check length and fill numbers
     * \param [in] length Length of happy number
     */
    public HappyNumbers(int length)
    {
        if ((length < 2) || (length % 2 != 0)) {
            Console.WriteLine("Needed even length");
            Environment.Exit(1);
        }
        // \todo Check If length > int
        halflength = length / 2;
        lastnumber = (int) Math.Pow(10, length - 1);
        biggest = (int) Math.Pow(10, length) - 1;
    }

    /*!
     * \brief Get next happy number
     * \return Returns happy number or 0
     */
    public int GetHappyNumber()
    {
        for (int i = lastnumber + 1; i <= biggest; i++) {
            int[] arr = i.ToString().Select(o=> Convert.ToInt32(o)).ToArray();
            int hhalf = 0, lhalf = 0;
            for (int j = 0; j < halflength; j++) {
                hhalf += arr[j];
                lhalf += arr[j + halflength];
            }
            if (hhalf == lhalf) {
                lastnumber = i;
                return i;
            }
        }
        lastnumber = biggest;
        return 0;
    }

    static void Main(string[] args)
    {
        int happyLength = 2; //Length of happy number
        int firstN = 10; //Write first happy numbers

        HappyNumbers happy = new HappyNumbers(happyLength);
        Console.WriteLine("Your numbers are:");
        for (int i = 0; i < firstN; i++) {
            Console.WriteLine("{0}", happy.GetHappyNumber());
        }
    }
}
