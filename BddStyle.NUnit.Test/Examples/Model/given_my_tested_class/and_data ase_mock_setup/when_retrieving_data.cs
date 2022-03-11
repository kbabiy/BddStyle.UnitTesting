using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Model.given_my_tested_class.and_data_ase_mock_setup;

public class when_retrieving_data : Context
{
    protected override void Act()
    {
        base.Act();
    }

    [Test]
    public void then_data_is_returned()
    { }

    [Test]
    public void then_database_is_called()
    { }
}