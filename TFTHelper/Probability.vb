Public Class Probability
    Private Shared Lv1Pro As Double() = {1, 1, 0.65, 0.5, 0.37, 0.245, 0.2, 0.15, 0.1}
    Private Shared Lv2Pro As Double() = {0, 0, 0.3, 0.35, 0.35, 0.35, 0.3, 0.25, 0.15}
    Private Shared Lv3Pro As Double() = {0, 0, 0.05, 0.15, 0.25, 0.3, 0.33, 0.35, 0.35}
    Private Shared Lv4Pro As Double() = {0, 0, 0, 0, 0.3, 0.1, 0.15, 0.2, 0.3}
    Private Shared Lv5Pro As Double() = {0, 0, 0, 0, 0, 0.005, 0.02, 0.05, 0.1}
    Private Shared Function AllProbabilityList() As Dictionary(Of Integer, Double())
        Dim ReturnList As New Dictionary(Of Integer, Double())
        ReturnList.Add(1, Lv1Pro)
        ReturnList.Add(2, Lv2Pro)
        ReturnList.Add(3, Lv3Pro)
        ReturnList.Add(4, Lv4Pro)
        ReturnList.Add(5, Lv5Pro)
        Return ReturnList
    End Function
    Private Shared Function AllChampionMax() As Dictionary(Of Integer, Integer)
        Dim ReturnList As New Dictionary(Of Integer, Integer)
        ReturnList.Add(1, DefaultValue.Default.Lv1_Champion_Max)
        ReturnList.Add(2, DefaultValue.Default.Lv2_Champion_Max)
        ReturnList.Add(3, DefaultValue.Default.Lv3_Champion_Max)
        ReturnList.Add(4, DefaultValue.Default.Lv4_Champion_Max)
        ReturnList.Add(5, DefaultValue.Default.Lv5_Champion_Max)
        Return ReturnList
    End Function

    Public Shared Function GeneralProbability(Player_Level As Integer) As List(Of Double)
        Dim ProbabilityList As New List(Of Double)
        For Each Pro As KeyValuePair(Of Integer, Double()) In AllProbabilityList()
            ProbabilityList.Add(Pro.Value(Player_Level - 1))
        Next
        Return ProbabilityList
    End Function
    Public Shared Function IndividualProbability(PlayerLevel As Integer, ChampionLevel As Integer, TargetChamp As Integer) As Double
        Dim ReturnProbability As Double
        Dim ProbabilityList As Double()
        ProbabilityList = AllProbabilityList(ChampionLevel)
        Dim ChampionMax As Integer = AllChampionMax(ChampionLevel)
        ReturnProbability = 1 - ((1 - (TargetChamp * ProbabilityList(PlayerLevel - 1) / ChampionMax)) ^ 5)
        Return ReturnProbability
    End Function
End Class