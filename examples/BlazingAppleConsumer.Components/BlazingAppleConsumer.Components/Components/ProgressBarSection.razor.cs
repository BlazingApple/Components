using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

/// <summary>Displays various Progress Bars</summary>
public partial class ProgressBarSection : ComponentBase
{
	private int _progressSingleNumerator = 25;
	private bool _progressSingleShowPercentComplete = false;
	private int _progressSingleDenominator = 100;
	private int _progressMultiNumerator = 25;
	private int _progressMultiDenominator = 100;
	private bool _passDenominator = true;
}
