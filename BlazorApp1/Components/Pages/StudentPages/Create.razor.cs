using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BlazorApp1.Components.Pages.StudentPages
{
    public partial class Create
    {
        [SupplyParameterFromForm]
        private Student Student { get; set; } = new();

        private async Task AddStudent()
        {
            using var context = DbFactory.CreateDbContext();
            context.Student.Add(Student);
            await context.SaveChangesAsync();

            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "Success",
                Detail = "Student created successfully",
                Duration = 4000
            });

            NavigationManager.NavigateTo("/students");
        }

        private void BackToList()
        {
            NavigationManager.NavigateTo("/students");
        }
    }
}
