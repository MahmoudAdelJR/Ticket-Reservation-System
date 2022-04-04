using System;

namespace project.net
{
    class Program
    {
        static void Main(string[] args)
        {
            #region you name
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(@"  
  *  *        * * **  *        * * **  *        * * *    *  *        * * *  *  *        * * * *  *        * * * *  *        * * *
   *  *  * * * *    *  *  * * * *    *  * * *        *  *  * * * *      *  *  * * * *     *  *  * * * *     *  *  * * * *   
    *   * *          *   * *          *   * *              *   * *            *   * *           *   * *           *   * *        
              *                * 
*                    *                  *                 *                 * ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(@"
                   ___      ___  ___  __          __        __                      ___           
                  |__  |\ |  |  |__  |__)    \ / /  \ |  | |__)    |\ |  /\   |\/| |__     .      
                  |___ | \|  |  |___ |  \     |  \__/ \__/ |  \    | \| /~~\  |  | |___    .      
                                                                                                  ");

            Console.ReadLine();
            Console.Clear();
            Console.ResetColor();

            #endregion
            #region Welcome
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(@"           ▄█     █▄     ▄████████  ▄█        ▄████████  ▄██████▄     ▄▄▄▄███▄▄▄▄      ▄████████           
          ███     ███   ███    ███ ███       ███    ███ ███    ███  ▄██▀▀▀███▀▀▀██▄   ███    ███           
          ███     ███   ███    █▀  ███       ███    █▀  ███    ███  ███   ███   ███   ███    █▀            
          ███     ███  ▄███▄▄▄     ███       ███        ███    ███  ███   ███   ███  ▄███▄▄▄               
          ███     ███ ▀▀███▀▀▀     ███       ███        ███    ███  ███   ███   ███ ▀▀███▀▀▀               
          ███     ███   ███    █▄  ███       ███    █▄  ███    ███  ███   ███   ███   ███    █▄            
          ███ ▄█▄ ███   ███    ███ ███▌    ▄ ███    ███ ███    ███  ███   ███   ███   ███    ███           
           ▀███▀███▀    ██████████ █████▄▄██ ████████▀   ▀██████▀    ▀█   ███   █▀    ██████████           
                                   ▀                                                                       ");
            Console.ResetColor();
            #endregion
            Mnue.startUp();
           
        }
    }
}
