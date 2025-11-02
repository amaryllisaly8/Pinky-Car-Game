Imports System.Media
Public Class Form1
    Dim player As New SoundPlayer("C:\Users\lyngr\Downloads\Epic 8-bit Electro Gaming Music Mix Royalty Free Chiptune Music.wav")
    Dim road(18) As PictureBox
    Dim cars(5) As PictureBox
    Dim cactus(11) As PictureBox
    Dim tree(10) As PictureBox

    Dim currentDifficulty As String = "Easy"

    Dim carLives As Integer = 3
    Dim fuelLevel As Integer = 100
    Private WithEvents fuelTimer As New Timer()
    Private gameStarted As Boolean = False
    Private ghostDirection As Integer = 5
    Private currentTheme As String = "City"
    Dim canCollide As Boolean = True


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If gameStarted = False Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        Select Case keyData
            Case Keys.Left
                If PictureBox19.Left > 0 Then
                    PictureBox19.Left -= 10
                End If
                Return True

            Case Keys.Right
                If PictureBox19.Right < PictureBox19.Parent.ClientSize.Width Then
                    PictureBox19.Left += 10
                End If
                Return True

            Case Keys.Up
                If PictureBox19.Top > 0 Then
                    PictureBox19.Top -= 10
                End If
                Return True

            Case Keys.Down
                If PictureBox19.Bottom < PictureBox19.Parent.ClientSize.Height Then
                    PictureBox19.Top += 10
                End If
                Return True
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click

        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False

        ' Set game speed depending on difficulty
        Select Case currentDifficulty
            Case "Easy"
                Timer1.Interval = 100
            Case "Medium"
                Timer1.Interval = 60
            Case "Hard"
                Timer1.Interval = 30
        End Select

    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        player.Load()
        player.PlayLooping()

        PanelGameOver.Visible = False

        Panel1.Visible = True     ' Main Menu (Play, Exit)
        Panel1.BringToFront()
        Panel2.Visible = False    ' Theme Selection (City, Dessert, Night)
        Panel3.Visible = False    ' Dessert Environment
        Panel4.Visible = False    ' Night Environment


        currentDifficulty = "Easy"
        PanelDifficulty.Visible = False

        lblCountdown.Visible = False
        lblCountdown.TextAlign = ContentAlignment.MiddleCenter


        Me.KeyPreview = True


        PictureBox19.Visible = True

        Me.ActiveControl = Nothing
        Me.Focus()

        carLives = 3
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()

        road(1) = PictureBox1
        road(2) = PictureBox2
        road(3) = PictureBox3
        road(4) = PictureBox4
        road(5) = PictureBox5
        road(6) = PictureBox6
        road(7) = PictureBox7
        road(8) = PictureBox8
        road(9) = PictureBox9
        road(10) = PictureBox10
        road(11) = PictureBox11
        road(12) = PictureBox12
        road(13) = PictureBox13
        road(14) = PictureBox14
        road(15) = PictureBox15
        road(16) = PictureBox16
        road(17) = PictureBox17
        road(18) = PictureBox18

        cars(1) = PictureBox20
        cars(2) = PictureBox21
        cars(3) = PictureBox22
        cars(4) = PictureBox23
        cars(5) = PictureBox24

        fuelBar.Value = fuelLevel

        With fuelTimer
            .Interval = 1000
            AddHandler .Tick, AddressOf fuelTimer_Tick
        End With


        Me.ClientSize = New Size(1103, 859)

        Panel1.Left = 0
        Panel1.Top = 0
        Panel1.Width = Me.ClientSize.Width
        Panel1.Height = Me.ClientSize.Height

        Panel2.Left = 0
        Panel2.Top = 0
        Panel2.Width = Me.ClientSize.Width
        Panel2.Height = Me.ClientSize.Height

        Panel3.Left = 0
        Panel3.Top = 0
        Panel3.Width = Me.ClientSize.Width
        Panel3.Height = Me.ClientSize.Height

        Panel4.Left = 0
        Panel4.Top = 0
        Panel4.Width = Me.ClientSize.Width
        Panel4.Height = Me.ClientSize.Height

        PanelDifficulty.Left = 0
        PanelDifficulty.Top = 0
        PanelDifficulty.Width = Me.ClientSize.Width
        PanelDifficulty.Height = Me.ClientSize.Height

        cactus(1) = PictureBox26
        cactus(2) = PictureBox27
        cactus(3) = PictureBox28
        cactus(4) = PictureBox29
        cactus(5) = PictureBox30
        cactus(6) = PictureBox31
        cactus(7) = PictureBox32
        cactus(8) = PictureBox33
        cactus(9) = PictureBox34
        cactus(10) = PictureBox35
        cactus(11) = PictureBox36

        Panel3.Controls.Add(PictureBox26)
        Panel3.Controls.Add(PictureBox27)
        Panel3.Controls.Add(PictureBox28)
        Panel3.Controls.Add(PictureBox29)
        Panel3.Controls.Add(PictureBox30)
        Panel3.Controls.Add(PictureBox31)
        Panel3.Controls.Add(PictureBox32)
        Panel3.Controls.Add(PictureBox33)
        Panel3.Controls.Add(PictureBox34)
        Panel3.Controls.Add(PictureBox35)
        Panel3.Controls.Add(PictureBox36)

        tree(1) = PictureBox39
        tree(2) = PictureBox40
        tree(3) = PictureBox41
        tree(4) = PictureBox42
        tree(5) = PictureBox43
        tree(6) = PictureBox44
        tree(7) = PictureBox45
        tree(8) = PictureBox46
        tree(9) = PictureBox47
        tree(10) = PictureBox48

        Panel4.Controls.Add(PictureBox39)
        Panel4.Controls.Add(PictureBox40)
        Panel4.Controls.Add(PictureBox41)
        Panel4.Controls.Add(PictureBox42)
        Panel4.Controls.Add(PictureBox43)
        Panel4.Controls.Add(PictureBox44)
        Panel4.Controls.Add(PictureBox45)
        Panel4.Controls.Add(PictureBox46)
        Panel4.Controls.Add(PictureBox47)
        Panel4.Controls.Add(PictureBox48)

        Panel5.Size = New Size(504, 642)
        Panel5.Left = (Me.ClientSize.Width - Panel5.Width) \ 2
        Panel5.Top = (Me.ClientSize.Height - Panel5.Height) \ 2
        Panel5.Visible = False

        PanelGameOver.Size = New Size(1191, 855)
        PanelGameOver.Location = New Point(0, 0)
        PanelGameOver.Visible = False

    End Sub

    Private Sub fuelTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles fuelTimer.Tick
        fuelLevel -= 1
        fuelBar.Value = fuelLevel

        If fuelLevel <= 0 Then
            fuelTimer.Stop()
            Timer1.Stop()
            Timer2.Stop()
            Timer3.Stop()
            TimerFastEnemy.Stop()
            ShowGameOverPanel()
            player.Stop()
            MsgBox("Game Over! You're out of fuel.")

        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        For x = 1 To 18
            road(x).Top += 15
            Dim h As Integer = If(road(x).Parent IsNot Nothing, road(x).Parent.ClientSize.Height, Me.ClientSize.Height)
            If road(x).Top >= h Then
                road(x).Top = -road(x).Height
            End If
        Next

        ' Fast enemy
        picFastEnemy.Top += 20
        Dim feParentH As Integer = If(picFastEnemy.Parent IsNot Nothing, picFastEnemy.Parent.ClientSize.Height, Me.ClientSize.Height)
        If picFastEnemy.Top > feParentH Then
            picFastEnemy.Top = -100
            picFastEnemy.Left = GetRandomX()
        End If


        For i As Integer = 1 To 11
            cactus(i).Top += 10
            Dim ch As Integer = If(cactus(i).Parent IsNot Nothing, cactus(i).Parent.ClientSize.Height, Me.ClientSize.Height)
            If cactus(i).Top >= ch Then
                cactus(i).Top = -cactus(i).Height

            End If
        Next


        For i As Integer = 1 To 10
            tree(i).Top += 10
            Dim th As Integer = If(tree(i).Parent IsNot Nothing, tree(i).Parent.ClientSize.Height, Me.ClientSize.Height)
            If tree(i).Top >= th Then
                tree(i).Top = -tree(i).Height
            End If
        Next


    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        For y = 1 To 5
            cars(y).Top += 10
            If cars(y).Top >= Me.Height Then
                cars(y).Top = -(Rnd() * 100)
            End If

            If canCollide AndAlso PictureBox19.Bounds.IntersectsWith(cars(y).Bounds) Then
                carLives -= 1
                canCollide = False
                collisionCooldown.Start()

                ' Reset player position
                PictureBox19.Left = CInt(Me.ClientSize.Width / 2 - PictureBox19.Width / 2)

                ' Hide one life icon per hit
                Select Case carLives
                    Case 2
                        picLife3.Visible = False
                    Case 1
                        picLife2.Visible = False
                    Case 0
                        picLife1.Visible = False
                        Timer1.Stop()
                        Timer2.Stop()
                        Timer3.Stop()
                        fuelTimer.Stop()
                        TimerFastEnemy.Stop()
                        ShowGameOverPanel()
                        player.Stop()

                        Exit Sub
                End Select
            End If
        Next


        ' Fuel logic
        picFuel1.Top += 10
        If picFuel1.Top >= Me.Height Then
            picFuel1.Top = -(Rnd() * 100)
            picFuel1.Left = CInt(Rnd() * (Me.Width - picFuel1.Width))
            picFuel1.Visible = True
        End If

        If PictureBox19.Bounds.IntersectsWith(picFuel1.Bounds) Then
            fuelLevel = Math.Min(fuelLevel + 20, 100)
            fuelBar.Value = fuelLevel
            picFuel1.Visible = False
        End If


    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Label1.Text = Val(Label1.Text) + 0.1
    End Sub
    Private Sub StartGame()
        TimerFastEnemy.Start()
        picFastEnemy.Visible = True

        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        fuelTimer.Start()

        Button1.Enabled = False
        Button1.Visible = False

        fuelLevel = 100
        fuelBar.Value = fuelLevel

        carLives = 3
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        picFuel1.Visible = True
        picFuel1.Top = -50

        PictureBox19.Left = CInt(Me.ClientSize.Width / 2 - PictureBox19.Width / 2)
        PictureBox19.Top = Me.ClientSize.Height - PictureBox19.Height - 10

        gameStarted = True
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        lblCountdown.Text = "3"
        lblCountdown.Visible = True
        TimerCountdown.Start()
        Button1.Enabled = False
        Button1.Visible = False
    End Sub


    Private Sub collisionCooldown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles collisionCooldown.Tick
        canCollide = True
        collisionCooldown.Stop()
    End Sub
    Private Sub TimerCountdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCountdown.Tick
        Select Case lblCountdown.Text
            Case "3"
                lblCountdown.Text = "2"
            Case "2"
                lblCountdown.Text = "1"
            Case "1"
                lblCountdown.Text = "GO!"
            Case "GO!"
                TimerCountdown.Stop()
                lblCountdown.Visible = False
                StartGame() ' 
        End Select
    End Sub

    Private Sub TimerFastEnemy_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerFastEnemy.Tick

        picFastEnemy.Top += 20


        For i = 1 To 5
            If picFastEnemy.Bounds.IntersectsWith(cars(i).Bounds) Then
                ' Try to move left or right to avoid
                If picFastEnemy.Left + picFastEnemy.Width + 50 < Me.Width Then
                    picFastEnemy.Left += 50 ' move right if there is space
                ElseIf picFastEnemy.Left - 50 > 0 Then
                    picFastEnemy.Left -= 50 ' else move left
                End If
            End If
        Next


        If picFastEnemy.Bounds.IntersectsWith(picFuel1.Bounds) Then
            ' Try to move left or right
            If picFastEnemy.Left + picFastEnemy.Width + 50 < Me.Width Then
                picFastEnemy.Left += 50
            ElseIf picFastEnemy.Left - 50 > 0 Then
                picFastEnemy.Left -= 50
            End If
        End If


        If picFastEnemy.Top > Me.Height Then
            picFastEnemy.Top = -100
            picFastEnemy.Left = GetRandomX()
        End If


        If picFastEnemy.Bounds.IntersectsWith(PictureBox19.Bounds) Then
            Timer1.Stop()
            Timer2.Stop()
            Timer3.Stop()
            TimerFastEnemy.Stop()
            fuelTimer.Stop()
            ShowGameOverPanel()
            player.Stop()

            gameStarted = False
        End If
    End Sub

    Private Function GetRandomX() As Integer
        Dim rnd As New Random()
        Dim lanes() As Integer = {120, 200, 280, 360}
        Return lanes(rnd.Next(0, lanes.Length))
    End Function

    Private Sub btnCity_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCity.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False

        ' Set timer speed based on difficulty
        Select Case currentDifficulty
            Case "Easy"
                Timer1.Interval = 100
            Case "Medium"
                Timer1.Interval = 60
            Case "Hard"
                Timer1.Interval = 30
        End Select
        gameStarted = True

        currentTheme = "City"
        ' Show City elements on Form1
        lblCountdown.Visible = True
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
        PictureBox10.Visible = True
        PictureBox11.Visible = True
        PictureBox12.Visible = True
        PictureBox13.Visible = True
        PictureBox14.Visible = True
        PictureBox15.Visible = True
        PictureBox16.Visible = True
        PictureBox17.Visible = True
        PictureBox18.Visible = True

        PictureBox20.Visible = True
        PictureBox21.Visible = True
        PictureBox22.Visible = True
        PictureBox23.Visible = True
        PictureBox24.Visible = True

        picFastEnemy.Visible = True
        picFuel1.Visible = True
        fuelBar.Visible = True


        PictureBox19.Parent = Me
        PictureBox19.Location = New Point(
           Me.ClientSize.Width \ 2 - PictureBox19.Width \ 2,
           Me.ClientSize.Height - PictureBox19.Height - 10)

        PictureBox19.Visible = True

        Me.ActiveControl = Nothing
        Me.Focus()

        player.PlayLooping()
    End Sub

    Private Sub btnNight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNight.Click
        currentTheme = "Night"
        ' Hide other panels
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False

        ' Show night panel
        Panel4.Visible = True
        Panel4.BringToFront()
        PanelDifficulty.Visible = True


        Button1.BringToFront()
        Button1.Visible = True
        Button1.Enabled = True

        btnExit1.BringToFront()
        btnExit1.Visible = True
        ' Set timer speed based on difficulty
        Select Case currentDifficulty
            Case "Easy"
                Timer1.Interval = 100
            Case "Medium"
                Timer1.Interval = 60
            Case "Hard"
                Timer1.Interval = 30
        End Select



        ' Move cars to Panel4 (only if not already parented)
        For i As Integer = 1 To 5
            If cars(i).Parent IsNot Panel4 Then Panel4.Controls.Add(cars(i))
        Next

        ' Move road/other game elements into Panel4 (game play elements should be in the active panel)
        Dim gameControls As Control() = {PictureBox19, picFastEnemy, picFuel1, picLife1, picLife2, picLife3, fuelBar, lblCountdown, Label1, Button1, PictureGhost}
        For Each c As Control In gameControls
            If c IsNot Nothing AndAlso c.Parent IsNot Panel4 Then
                Panel4.Controls.Add(c)
            End If
        Next


        picFastEnemy.Visible = True
        picFuel1.Visible = True
        fuelBar.Visible = True


        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False
        PictureBox14.Visible = False
        PictureBox15.Visible = False
        PictureBox16.Visible = False
        PictureBox17.Visible = False
        PictureBox18.Visible = False

        ' Hide city images (if any)
        For x As Integer = 1 To 18
            road(x).Visible = False
        Next

        ' Prepare and start ghost (in Panel4)
        PictureGhost.Left = 0
        PictureGhost.Top = 100
        PictureGhost.Visible = True
        ghostDirection = 5 ' keep the variable exactly as you declared it
        tmrGhost.Interval = 50
        tmrGhost.Start()


        PictureBox19.Parent = Panel4
        PictureBox19.Location = New Point(
            Panel4.ClientSize.Width \ 2 - PictureBox19.Width \ 2,
            Panel4.ClientSize.Height - PictureBox19.Height - 10)

        PictureBox19.Visible = True

        Me.ActiveControl = Nothing
        Me.Focus()

        player.PlayLooping()
    End Sub



    Private Sub btnDessert_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDessert.Click
        Panel2.Visible = False
        Panel3.Visible = True
        Panel3.BringToFront()
        Panel1.Visible = False
        Panel4.Visible = False

        Button1.BringToFront()
        Button1.Visible = True
        Button1.Enabled = True

        btnExit1.BringToFront()
        btnExit1.Visible = True
        currentTheme = "Dessert"

        ' Set timer speed based on difficulty
        Select Case currentDifficulty
            Case "Easy"
                Timer1.Interval = 100
            Case "Medium"
                Timer1.Interval = 60
            Case "Hard"
                Timer1.Interval = 30
        End Select



        ' Move cars to Panel3
        For i As Integer = 1 To 5
            Panel3.Controls.Add(cars(i))
        Next

        ' Move road (if using road pictures for background)
        For i As Integer = 1 To 18
            Panel3.Controls.Add(road(i))
        Next

        ' Move other game elements
        Panel3.Controls.Add(PictureBox19)      ' Player car
        Panel3.Controls.Add(picFastEnemy)      ' Fast enemy
        Panel3.Controls.Add(picFuel1)          ' Fuel
        Panel3.Controls.Add(picLife1)
        Panel3.Controls.Add(picLife2)
        Panel3.Controls.Add(picLife3)
        Panel3.Controls.Add(fuelBar)
        Panel3.Controls.Add(lblCountdown)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(Button1)



        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False
        PictureBox14.Visible = False
        PictureBox15.Visible = False
        PictureBox16.Visible = False
        PictureBox17.Visible = False
        PictureBox18.Visible = False

        PictureBox19.Visible = True

        PictureBox19.Parent = Panel3
        PictureBox19.Location = New Point(
            Panel3.ClientSize.Width \ 2 - PictureBox19.Width \ 2,
            Panel3.ClientSize.Height - PictureBox19.Height - 10)

        Me.ActiveControl = Nothing
        Me.Focus()

        player.PlayLooping()
    End Sub

    Private Sub btnDifficulty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDifficulty.Click
        Panel1.Visible = False
        PanelDifficulty.Visible = True
    End Sub


    Private Sub btnEasy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEasy.Click
        currentDifficulty = "Easy"
        PanelDifficulty.Visible = False
        Panel2.Visible = True ' show theme choices
    End Sub

    Private Sub btnMedium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedium.Click
        currentDifficulty = "Medium"
        PanelDifficulty.Visible = False
        Panel2.Visible = True ' show theme choices
    End Sub

    Private Sub btnHard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHard.Click
        currentDifficulty = "Hard"
        PanelDifficulty.Visible = False
        Panel2.Visible = True ' show theme choices
    End Sub


    Private Sub tmrGhost_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGhost.Tick
        If Not gameStarted Then Exit Sub

        ' Move ghost left to right
        PictureGhost.Left += ghostDirection

        If PictureGhost.Right >= Me.ClientSize.Width Then
            ghostDirection = -ghostDirection
        ElseIf PictureGhost.Left <= 0 Then
            ghostDirection = 5
        End If

        ' Check collision with PictureBox19 (player)
        If PictureGhost.Bounds.IntersectsWith(PictureBox19.Bounds) Then
            ' Only process collision if allowed (avoid rapid life loss)
            If canCollide Then
                carLives -= 1
                canCollide = False
                collisionCooldown.Start()  ' Assuming you have this cooldown timer

                ' Hide life icons based on remaining lives
                Select Case carLives
                    Case 2
                        picLife3.Visible = False
                    Case 1
                        picLife2.Visible = False
                    Case 0
                        picLife1.Visible = False
                        ' Stop game - Game Over
                        gameStarted = False
                        Timer1.Stop()
                        Timer2.Stop()
                        Timer3.Stop()
                        tmrGhost.Stop()
                        fuelTimer.Stop()
                        ShowGameOverPanel()
                        player.Stop()


                End Select
            End If

            ' Optional: Push ghost away so it doesn’t immediately trigger again
            PictureGhost.Left = 0
        End If

        ' Ghost interaction with fast enemy (optional)
        If PictureGhost.Bounds.IntersectsWith(picFastEnemy.Bounds) Then
            picFastEnemy.Top += 20
        End If
    End Sub


    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        ' If Play screen is visible, go back to Main Menu
        If Panel2.Visible Then
            Panel2.Visible = False
            Panel1.Visible = True
            ' If Difficulty panel is visible, go back to Main Menu
        ElseIf PanelDifficulty.Visible Then
            PanelDifficulty.Visible = False
            Panel1.Visible = True
        Else
            ' Default: just show main menu
            Panel1.Visible = True
            Panel2.Visible = False
            PanelDifficulty.Visible = False
        End If
    End Sub

    Private Sub btnBack2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack2.Click
        ' If Play screen is visible, go back to Main Menu
        If Panel3.Visible Then
            Panel3.Visible = False
            Panel1.Visible = True
            ' If Difficulty panel is visible, go back to Main Menu
        ElseIf PanelDifficulty.Visible Then
            PanelDifficulty.Visible = False
            Panel1.Visible = True
        Else
            ' Default: just show main menu
            Panel1.Visible = True
            Panel3.Visible = False
            PanelDifficulty.Visible = False
        End If
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        TimerFastEnemy.Stop()
        fuelTimer.Stop()
        collisionCooldown.Stop()


        player.Stop()

        gameStarted = False
        fuelLevel = 100
        fuelBar.Value = fuelLevel

        carLives = 3
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        Label1.Text = "0"


        PictureBox19.Left = CInt(Me.ClientSize.Width / 2 - PictureBox19.Width / 2)
        PictureBox19.Top = Me.ClientSize.Height - PictureBox19.Height - 10


        picFastEnemy.Top = -100
        For i As Integer = 1 To cars.Length - 1
            cars(i).Top = -(Rnd() * 100)
        Next


        Button1.Enabled = True
        Button1.Visible = True

        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False


        Panel1.Visible = True
        Panel1.BringToFront()

    End Sub

    Private Sub btnExit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit1.Click
        If Panel5.Visible = False Then
            Panel5.Visible = True
            Panel5.BringToFront()
        Else
            Panel5.Visible = False
        End If
    End Sub


    Private Sub btnBackToGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel5.Visible = False

        Select Case currentTheme
            Case "City"
                Panel1.Visible = True
                Panel1.BringToFront()
                Panel3.Visible = False
                Panel4.Visible = False

            Case "Dessert"
                Panel3.Visible = True
                Panel3.BringToFront()
                Panel1.Visible = False
                Panel4.Visible = False

            Case "Night"
                Panel4.Visible = True
                Panel4.BringToFront()
                Panel1.Visible = False
                Panel3.Visible = False

            Case Else
                ' Default to City
                Panel1.Visible = True
                Panel1.BringToFront()
                Panel3.Visible = False
                Panel4.Visible = False
        End Select
    End Sub

    Private Sub btnMusic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMusic.Click
        player.PlayLooping()
    End Sub

    Private Sub ShowGameOverPanel()
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        TimerFastEnemy.Stop()
        fuelTimer.Stop()

        ' Stop music
        player.Stop()

        ' Hide all game panels
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False

        ' Show Game Over
        PanelGameOver.Visible = True
        PanelGameOver.BringToFront()

        btnExit1.Visible = True
        btnExit1.BringToFront()

        gameStarted = False
    End Sub

    Private Sub btnRestart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestart.Click
        PanelGameOver.Visible = False
        Button1.Enabled = True
        Button1.Visible = True

        btnExit1.Visible = True
        btnExit1.BringToFront()

        ' Stop everything
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        TimerFastEnemy.Stop()
        fuelTimer.Stop()

        ' Reset variables
        fuelLevel = 100
        fuelBar.Value = fuelLevel
        carLives = 3
        Label1.Text = "0.0"
        gameStarted = False

        ' Show all lives
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        ' Reset player position
        PictureBox19.Left = CInt(Me.ClientSize.Width / 2 - PictureBox19.Width / 2)
        PictureBox19.Top = Me.ClientSize.Height - PictureBox19.Height - 10

        ' Reset fuel position
        picFuel1.Visible = True
        picFuel1.Top = -50

        ' Reset enemy position
        picFastEnemy.Top = -100
        picFastEnemy.Left = GetRandomX()

        ' Hide Game Over panel
        PanelGameOver.Visible = False

        ' Go back to theme selection (depending on currentTheme)
        Select Case currentTheme
            Case "City"
                Panel1.Visible = True
                Panel1.BringToFront()

            Case "Dessert"
                Panel3.Visible = True
                Panel3.BringToFront()
                btnExit1.Visible = True

            Case "Night"
                Panel4.Visible = True
                Panel4.BringToFront()
                btnExit1.Visible = True
        End Select


        player.PlayLooping()
        gameStarted = False
    End Sub


    Private Sub btnExitGame_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExitGame.Click
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        TimerFastEnemy.Stop()
        fuelTimer.Stop()
        collisionCooldown.Stop()


        player.Stop()


        gameStarted = False
        fuelLevel = 100
        fuelBar.Value = fuelLevel

        carLives = 3
        picLife1.Visible = True
        picLife2.Visible = True
        picLife3.Visible = True

        Label1.Text = "0" ' reset score


        PictureBox19.Left = CInt(Me.ClientSize.Width / 2 - PictureBox19.Width / 2)
        PictureBox19.Top = Me.ClientSize.Height - PictureBox19.Height - 10
        picFastEnemy.Top = -100

        For i As Integer = 1 To cars.Length - 1
            cars(i).Top = -(Rnd() * 100)
        Next


        Button1.Enabled = True
        Button1.Visible = True


        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        PanelGameOver.Visible = False


        Panel1.Visible = True
        Panel1.BringToFront()

    End Sub

    Private Sub btnMute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMute.Click
        player.Stop()
    End Sub

    
    Private Sub fuelBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fuelBar.Click

    End Sub
End Class
