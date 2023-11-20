namespace WPFApp.Members
{
    class Member
    {
        public int Id { get; set; }                 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }  
        public override string ToString()
        {
            return $"ID:{Id} Name:{Name} LastName:{LastName} Email:{Email} Passwors:{Password} IsActive{IsActive}";
        }

    }
}
