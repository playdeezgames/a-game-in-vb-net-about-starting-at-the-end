Module SfxHandler
    Sub HandleSfx(sfx As Sfx)
        Select Case sfx
            Case Sfx.Title
                PlayTitle()
            Case Sfx.BumpWall
                PlayBumpWall()
            Case Sfx.EnemyHit
                PlayEnemyHit()
            Case Sfx.EnemyMiss
                PlayEnemyMiss()
            Case Sfx.HealthUp
                PlayHealthUp()
            Case Sfx.PlayerHit
                PlayPlayerHit()
            Case Sfx.PlayerMiss
                PlayPlayerMiss()
            Case Sfx.Death
                PlayDeath()
            Case Sfx.RunAway
                PlayRunAway()
            Case Sfx.KillEnemy
                PlayKillEnemy()
            Case Sfx.Win
                PlayWin()
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub

    Private Sub PlayWin()
        Play("L250;A4;A4;A4;A4;L500;F#4;L250;A4;B4;A4;G#4;L500;A4;F#4")
    End Sub

    Private Sub PlayKillEnemy()
        Play("L250;C4;C4;C4;L500;G4")
    End Sub

    Private Sub PlayRunAway()
        Play("L500;F#4")
    End Sub

    Private Sub PlayDeath()
        Play("L500;C4;L250;G3;G3;L500;G#3;G3;R500;B3;C4")
    End Sub

    Private Sub PlayPlayerMiss()
        Play("L500;B2")
    End Sub

    Private Sub PlayPlayerHit()
        Play("L500;B4")
    End Sub

    Private Sub PlayHealthUp()
        Play("L250;D4;F#4;A4;L500;D5;L250;A4;L1000;D5")
    End Sub

    Private Sub PlayEnemyMiss()
        Play("L500;G2")
    End Sub

    Private Sub PlayEnemyHit()
        Play("L500;G4")
    End Sub

    Private Sub PlayBumpWall()
        Play("L500;F#2")
    End Sub

    Private Sub PlayTitle()
        PlayStatement.Play("L500;C4;E4;G4;C5;G4;E4;C4")
    End Sub
End Module
