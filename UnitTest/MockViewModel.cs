namespace UnitTest
{
    internal class MockViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public MockViewModel() {

        }



        public bool Validate()
        {
            bool isValidTitle = ValidateTitle();
            bool isValidDesc = ValidateDescription();
            bool isValidAuthor = ValidateAuthor();
            bool isValidPages = ValidatePages();
            return isValidTitle && isValidDesc && isValidAuthor && isValidPages;
        }

        private bool ValidateTitle()
        {
            if (Title != null && Title != "" && Title.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateDescription()
        {
            if (Description != null && Description != "" && Description.Length > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateAuthor()
        {
            if (Author != null && Author != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePages()
        {
            if (Pages != null && Pages > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
