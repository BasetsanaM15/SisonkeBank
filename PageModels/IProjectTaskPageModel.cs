using CommunityToolkit.Mvvm.Input;
using SisonkeBank.Models;

namespace SisonkeBank.PageModels;

public interface IProjectTaskPageModel
{
	IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
	bool IsBusy { get; }
}