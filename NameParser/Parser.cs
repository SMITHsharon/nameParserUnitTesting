using System;

namespace NameParser
{
    public class Parser
    {
        private string[] namePieces;
        private int i = 0; // namePieces index

        public User ParseName (string name)
        {
            var user = new User();

            namePieces = name.Split(' ');

            if (nameHasPrefix(namePieces[i])) // i = 0
            {
                user.Prefix = namePieces[i];
                i++;
            }
            
            // assume all names have First Name
            user.FirstName = namePieces[i];
            i++;

            // Middle Initial / Last Name / Suffix
            if (namePieces.Length > 1) // need for names that are ONLY First name e.g., Madonna
            {
                if (nameHasMiddleInit(namePieces[i]))
                {
                    user.MiddleInitial = namePieces[i];
                    i++;
                }

                user.LastName = namePieces[i];

                if (nameHasSuffix(namePieces.Length, i+1))
                {
                    i++;
                    if (i <= namePieces.Length)
                    {
                        user.Suffix = namePieces[i];
                    }
                }
            }
        return user;
        }

    
        public bool nameHasPrefix (string thisName)
        {
            char lastChar = thisName[thisName.Length - 1];
            return ((thisName.Length>2) && lastChar == '.') ? true : false;
        }


        public bool nameHasMiddleInit (string thisName)
        {
            return ((thisName.Length == 1) || thisName[1] == '.') ? true : false;
        }


        public bool nameHasSuffix (int arrayLength, int i)
        {
            return ((i+1 == arrayLength)) ? true : false;
           }
    }
}