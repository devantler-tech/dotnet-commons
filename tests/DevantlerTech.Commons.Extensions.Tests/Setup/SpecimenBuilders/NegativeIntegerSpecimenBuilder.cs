using AutoFixture;
using AutoFixture.Kernel;

namespace DevantlerTech.Commons.Extensions.Tests.Setup.SpecimenBuilders;

/// <summary>
/// A specimen builder for negative integers.
/// </summary>
sealed class NegativeIntegerSpecimenBuilder : ISpecimenBuilder
{
  /// <inheritdoc/>
  public object Create(object request, ISpecimenContext context) =>
    request is int ? context.Create<int>() * -1 : new NoSpecimen();
}
