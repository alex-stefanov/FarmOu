using FarmOu.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmOu.Data.Configurations;

public class ZdravkaTableConfiguration
    : IEntityTypeConfiguration<ZdravkaTable>
{
    public void Configure(
        EntityTypeBuilder<ZdravkaTable> builder)
    {
        var lines = File.ReadAllLines("../../../../FarmOu.Data/Data/zdravkaTables.txt");

        List<ZdravkaTable> zdravkaTables = [];

        foreach (string line in lines)
        {
            string[] properties = line.Split(',');

            var zdravkaTable = new ZdravkaTable
            {
                Id = int.Parse(properties[0]),
                Name = properties[1],
                Description = properties[2],
            };

            zdravkaTables.Add(zdravkaTable);
        }

        builder.HasData(zdravkaTables);
    }
}
