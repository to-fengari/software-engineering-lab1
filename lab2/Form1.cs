namespace lab2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// Recursion: the method calls itself with a smaller value until it
		// reaches the base case, which by definition is 0! = 1.
		// checked makes an overflow throw instead of silently wrapping negative,
		// which matters here because 21! already exceeds a long.
		public long RecursiveFactorial(long n)
		{
			if (n == 0) return 1;
			return checked(n * RecursiveFactorial(n - 1));
		}

		private void btnCalculateFactorial_Click(object sender, EventArgs e)
		{
			try
			{
				long number = long.Parse(txtInput.Text);
				if (number < 0)
				{
					lblResult.Text = "Factorial: n must be 0 or greater.";
					return;
				}
				lblResult.Text = $"Factorial: {RecursiveFactorial(number)}";
			}
			catch (FormatException)
			{
				lblResult.Text = "Factorial: enter a whole number first.";
			}
			catch (OverflowException)
			{
				lblResult.Text = "Factorial: that number is too large to hold.";
			}
		}

		// Walks the array from the last index down to the base case, adding
		// one element per call instead of looping.
		public long RecursiveSum(long[] numbers, int n)
		{
			if (n < 0) return 0;
			return numbers[n] + RecursiveSum(numbers, n - 1);
		}

		private void btnCalculateSum_Click(object sender, EventArgs e)
		{
			try
			{
				long[] numbers = txtArrayInput.Text.Split(',').Select(long.Parse).ToArray();
				lblSumResult.Text = $"Sum: {RecursiveSum(numbers, numbers.Length - 1)}";
			}
			catch (FormatException)
			{
				lblSumResult.Text = "Sum: enter numbers separated by commas.";
			}
		}

		// Two base cases, and the step calls itself twice: F(n) = F(n-1) + F(n-2).
		public long RecursiveFibonacci(long n)
		{
			if (n <= 0) return 0;
			if (n == 1) return 1;
			return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
		}

		private void btnCalculateFibonacci_Click(object sender, EventArgs e)
		{
			try
			{
				long n = long.Parse(txtFibInput.Text);
				if (n > 45)
				{
					lblFibResult.Text = "Fibonacci: keep n at 45 or less, it doubles the work each step.";
					return;
				}
				lblFibResult.Text = $"Fibonacci: {RecursiveFibonacci(n)}";
			}
			catch (FormatException)
			{
				lblFibResult.Text = "Fibonacci: enter a whole number first.";
			}
		}

		// x raised to n, peeling one multiplication off per call until n reaches 0.
		public long RecursivePower(long x, long n)
		{
			if (n == 0) return 1;
			return checked(x * RecursivePower(x, n - 1));
		}

		private void btnCalculatePower_Click(object sender, EventArgs e)
		{
			try
			{
				long x = long.Parse(txtBase.Text);
				long n = long.Parse(txtExponent.Text);
				if (n < 0)
				{
					lblPowerResult.Text = "Result: the exponent must be 0 or greater.";
					return;
				}
				lblPowerResult.Text = $"{x} to the power of {n} is {RecursivePower(x, n)}";
			}
			catch (FormatException)
			{
				lblPowerResult.Text = "Result: enter a base and an exponent first.";
			}
			catch (OverflowException)
			{
				lblPowerResult.Text = "Result: that result is too large to hold.";
			}
		}
	}
}
