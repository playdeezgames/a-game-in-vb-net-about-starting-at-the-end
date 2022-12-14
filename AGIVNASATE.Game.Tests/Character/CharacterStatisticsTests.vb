Public Class CharacterStatisticsTests
    Inherits BaseGameTests(Of ICharacterStatistics)
    Sub New()
        MyBase.New(AddressOf CharacterStatistics.FromId)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheSatietyStatisticsForAGiveCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Satiety
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.HungerStatisticTypeId))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.MaximumSatietyStatisticTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheHealthStatisticsForAGiveCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Health
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.MaximumHealthStatisticTypeId))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.WoundsStatisticTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheAttackStatisticForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                worldData.Setup(Function(x) x.CharacterStatisticBuff.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Attack
                actual.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.AttackStatisticTypeId))
                worldData.Verify(Function(x) x.CharacterStatisticBuff.Read(id, CharacterStatistics.AttackStatisticTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheDefendStatisticForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                worldData.Setup(Function(x) x.CharacterStatisticBuff.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Defend
                actual.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.DefendStatisticTypeId))
                worldData.Verify(Function(x) x.CharacterStatisticBuff.Read(id, CharacterStatistics.DefendStatisticTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAnIndicationOfDeathForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.IsDead.ShouldBeTrue
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.MaximumHealthStatisticTypeId))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, CharacterStatistics.WoundsStatisticTypeId))
            End Sub)
    End Sub
End Class
