
Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim Target_Default As Integer = 1
        Lv_TextBlock.Text = Target_Default
        Lv1_TextBlock.Text = Target_Default
        Lv2_TextBlock.Text = Target_Default
        Lv3_TextBlock.Text = Target_Default
        Lv4_TextBlock.Text = Target_Default
        Lv5_TextBlock.Text = Target_Default

        Dim Probabilities As List(Of Double) = Probability.GeneralProbability(Target_Default)
        Dim i As Integer = 0
        For Each TBlock In GeneralTBlockList()
            TBlock.Text = Probabilities(i).ToString("##0.#%")
            i += 1
        Next
    End Sub

    Private Sub UpdateAllProbability(sender As Object, e As RoutedEventArgs) Handles Lv_Minus.Click, Lv_Plus.Click
        Dim TargetBlockID As String() = sender.Uid.ToString.Split(",")
        Dim TblockLevel As Integer = Integer.Parse(TargetBlockID(0))
        Dim PlusOrMinus As Integer = Integer.Parse(TargetBlockID(1))
        Dim NowLevel As Integer = Lv_TextBlock.Text
        If (PlusOrMinus = 0 And NowLevel > 1) Or (PlusOrMinus = 1 And NowLevel < DefaultValue.Default.PlayerLevel_Max) Then
            Select Case PlusOrMinus
                Case 0
                    '-の場合
                    Minus_Count(Lv_TextBlock)
                    NowLevel -= 1
                Case 1
                    '+の場合
                    Plus_Count(Lv_TextBlock)
                    NowLevel += 1
            End Select
            'GeneralProbabilityの更新
            Dim Probabilities As List(Of Double) = Probability.GeneralProbability(NowLevel)
            Dim i As Integer = 0
            For Each TBlock In GeneralTBlockList()
                TBlock.Text = Probabilities(i).ToString("##0.#%")
                i += 1
            Next

            'IndividualProbabilityの更新
            For Level As Integer = 0 To DefaultValue.Default.ChampionLevel_Max - 1
                Dim Tblocks As New TBlocks(Me, Level)
                Dim target As Integer = Tblocks.Target.Text
                Tblocks.Individual.Text = (Probability.IndividualProbability(NowLevel, Level + 1, target)).ToString("##0.#%")
            Next
        End If
    End Sub

    Private Sub UpdateIndividualProbability(sender As Object, e As RoutedEventArgs) Handles Lv1_Minus.Click, Lv1_Plus.Click,
                                                                              Lv2_Minus.Click, Lv2_Plus.Click,
                                                                              Lv3_Minus.Click, Lv3_Plus.Click,
                                                                              Lv4_Minus.Click, Lv4_Plus.Click,
                                                                              Lv5_Minus.Click, Lv5_Plus.Click

        Dim TargetBlockID As String() = sender.Uid.ToString.Split(",")
        Dim TblockLevel As Integer = Integer.Parse(TargetBlockID(0))
        Dim PlusOrMinus As Integer = Integer.Parse(TargetBlockID(1))
        Dim Tblocks As New TBlocks(Me, TblockLevel - 1)
        Dim NowLevel As Integer = Lv_TextBlock.Text
        Dim TargetLevel As Integer

        If (PlusOrMinus = 0 And Int(Tblocks.Target.Text) > 1) Or (PlusOrMinus = 1 And Int(Tblocks.Target.Text) < Tblocks.TargetMax) Then
            Select Case PlusOrMinus
                Case 0
                    '-の場合
                    Minus_Count(Tblocks.Target)
                    TargetLevel = Tblocks.Target.Text
                Case 1
                    '+の場合
                    Plus_Count(Tblocks.Target)
                    TargetLevel = Tblocks.Target.Text
            End Select
            Tblocks.Individual.Text = (Probability.IndividualProbability(NowLevel, TblockLevel, TargetLevel)).ToString("##0.#%")
        End If
    End Sub

    Private Sub Plus_Count(TBlock As TextBlock)
        Dim NowValue As Integer = Int(TBlock.Text)
        TBlock.Text = (NowValue + 1).ToString
    End Sub
    Private Sub Minus_Count(TBlock As TextBlock)
        Dim NowValue As Integer = Int(TBlock.Text)
        TBlock.Text = (NowValue - 1).ToString
    End Sub


    Private Class TBlocks
        Public Property General As TextBlock
        Public Property Individual As TextBlock
        Public Property Target As TextBlock

        Public Property TargetMax As Integer

        Public Sub New(a As MainWindow, ChampionLevel As Integer)
            General = a.GeneralTBlockList(ChampionLevel)
            Individual = a.IndividualTBlockList(ChampionLevel)
            Target = a.TargetTBlockList(ChampionLevel)
            TargetMax = a.ChampionMaxList(ChampionLevel)
        End Sub
    End Class

    Public Function GeneralTBlockList() As List(Of TextBlock)
        Dim ReturnBlock As New List(Of TextBlock)
        ReturnBlock.Add(Pro_Lv1_General)
        ReturnBlock.Add(Pro_Lv2_General)
        ReturnBlock.Add(Pro_Lv3_General)
        ReturnBlock.Add(Pro_Lv4_General)
        ReturnBlock.Add(Pro_Lv5_General)
        Return ReturnBlock
    End Function

    Public Function TargetTBlockList() As List(Of TextBlock)
        Dim RetrunBlock As New List(Of TextBlock)
        RetrunBlock.Add(Lv1_TextBlock)
        RetrunBlock.Add(Lv2_TextBlock)
        RetrunBlock.Add(Lv3_TextBlock)
        RetrunBlock.Add(Lv4_TextBlock)
        RetrunBlock.Add(Lv5_TextBlock)
        Return RetrunBlock
    End Function

    Public Function IndividualTBlockList() As List(Of TextBlock)
        Dim RetrunBlock As New List(Of TextBlock)
        RetrunBlock.Add(Pro_Lv1)
        RetrunBlock.Add(Pro_Lv2)
        RetrunBlock.Add(Pro_Lv3)
        RetrunBlock.Add(Pro_Lv4)
        RetrunBlock.Add(Pro_Lv5)
        Return RetrunBlock
    End Function

    Public Function ChampionMaxList() As List(Of Integer)
        Dim RetrunBlock As New List(Of Integer)
        RetrunBlock.Add(DefaultValue.Default.Lv1_Champion_Max)
        RetrunBlock.Add(DefaultValue.Default.Lv2_Champion_Max)
        RetrunBlock.Add(DefaultValue.Default.Lv3_Champion_Max)
        RetrunBlock.Add(DefaultValue.Default.Lv4_Champion_Max)
        RetrunBlock.Add(DefaultValue.Default.Lv5_Champion_Max)
        Return RetrunBlock
    End Function

End Class
