using System.ComponentModel;
using UnitTest.Domain.Enums;

namespace UnitTest.Domain.Extentions
{
    public static class ValidationExtention
    {
        public static string Description(this Message message)
        {
            var type = message.GetType();
            var memberInfo = type.GetMember(message.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
