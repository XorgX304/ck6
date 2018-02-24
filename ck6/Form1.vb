'                                                                    .-""-.                    _
'                                                                   /  _   \              _   /|)
'                                                                 .'---""-.|             /|) /|/
'                                                               .'          `.          /|/ /|/
'                                                            __/_             \    .   /|/ /|/
'                                                          .'    `-.          .8-. \\-/|/ /|/
'                                                         J   .--.  Y     .o./ .o8\ |/\ `/_.-.
'                                                         |  (    \       98P  888| /\ / ( ` |
'                                                         |  `-._/          |   `"|/\ / \|\  F
'                                                          `.     .            "-'|\ / \/\  J
'                                                            |---'              _/\ / \// ` |
'                                                            J                 /// /   /   F
'                                                            _\    .'`-._    ./// /   /\\.'
'                                                           /  `. / .-'  `<-'/// /  _/\ \\
'                                                           F.--.\||       `.`/ /.-' )|\ \`.
'                                                           \__.-/)'         `.-'   ')/\\  / 
'                                                          .-' .'/  \               ')  `-'
'                                                         (  .'.'   '`.            .'
'                                                          \'.'    '   `.       .-'
'                                                           /     '      `.__.-'/|
'                                                          J     :          `._/ |
'                                                          |     :               |
'                                                          J     ;-"""-.         F
'                                                           \   /       \       /
'                                                            `.J         L   _.'
'                                                              F         |--' |
'                                                              J         |    |__
'                                                               L        |       `.
'                                                               |        |-.      \|
'                                                               |           \   )_.'
'                                                               F        -.\ )-'
'                                                               \         )_)
'                                                                `"""""""'

REM 9:43PM | 06/09/2017 (DD/MM/YY)

Imports System.Diagnostics

Public Class Form1
    Dim taskkillproc As New ProcessStartInfo()
    Dim targetlist As String = "Handy Cafe/hndclient/_hndguard/Cafe Manila/CafeClient/null/True Cafe/TrueCafe.exe/Client.exe"
    Dim tlacount As Integer
    Dim tlarray() As String
    Dim kill_attempt As Integer = 0
    Dim kill_cycle As Integer = 0
    Dim a As New Random()

    Private Sub writecon(aa As String)
        cons.Text = aa + vbNewLine + cons.Text
    End Sub

    Private Sub autoscanclient()
        Dim tlcount As Integer = 0
        Dim cyccount As Integer = 0
        Dim clnamecount As Integer = -3
        REM count how many clients to check
        For Each asd32 In tlarray
            If asd32 = "" Then
            Else
                tlcount += 1
            End If
        Next
        tlcount = tlcount \ 3
        writecon("Client Scan started! Scan Items: " + (tlcount).ToString)
        REM Scan for each client.
        For ghjhdbft = 1 To tlcount
            cyccount += 1
            clnamecount += 3
            writecon("Scanning for: " + tlarray(clnamecount) + " (" + cyccount.ToString + "/" + tlcount.ToString + ")")
            If Process.GetProcessesByName((tlarray(clnamecount + 1))).Count > 0 Then
                client_name = tlarray(clnamecount)
                client = tlarray(clnamecount + 1)
                guard = tlarray(clnamecount + 2)
            Else
            End If
        Next
        If client_name = "" Then
            writecon("Scan Complete! No Client detected!")
        Else
            writecon("Scan Complete! Detected Client: " + client_name)
            Call refreshtext()
        End If
    End Sub

    Private Sub refreshtext()
        If client_name = "" Then
            cl_name.Text = ": Waiting..."
        Else
            cl_name.Text = ": " + client_name
        End If

        If client = "" Then
            cl_proc.Text = ": Waiting..."
        Else
            cl_proc.Text = ": " + client
        End If

        If guard = "" Then
            cl_gproc.Text = ": Waiting..."
        Else
            cl_gproc.Text = ": " + guard
        End If
        reftick.Text = ": " + kill_attempt.ToString + " Kill Attempt | " + kill_cycle.ToString + " Tick Cycled"
    End Sub

    Private Sub fun_Tick(sender As Object, e As EventArgs) Handles fun.Tick
        Dim a1 As New Point()
        a1 = Me.Location
        Dim b As Integer = (a1.Y + 50)
        Dim c As Integer = (a1.X + 515)
        adv.Location = New Point(c, b)
    End Sub

    Private Sub manualimport()
        If Process.GetProcessesByName(TextBox1.Text).Count > 0 Then
            writecon("Custom Client detected! setting up values...")
            client_name = "Custom Client"
            client = TextBox1.Text
            guard = TextBox2.Text
            FlatButton3.Text = "Manual"
            Me.Height = 337
            FlatButton1.Enabled = True
            FlatButton2.Enabled = True
            FlatButton4.Enabled = True
            TextBox1.Text = ""
            TextBox2.Text = ""
            Me.FlatButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
            Call refreshtext()
        Else
            writecon("Custom Client returned Undetected!")
            Dim ovrd = MsgBox("The process name of the Client doesn't exist / was undetected. Would you like to Override and use this custom Process names as your Target?", MsgBoxStyle.YesNo, "Override?")
            If ovrd = vbYes Then
                cons.Text = "Override! Setting up custom Client!" + vbNewLine + cons.Text
                client_name = "Custom Client - OVR!"
                client = TextBox1.Text
                guard = TextBox2.Text
                FlatButton3.Text = "Manual"
                Me.Height = 337
                FlatButton1.Enabled = True
                FlatButton2.Enabled = True
                FlatButton4.Enabled = True
                TextBox1.Text = ""
                TextBox2.Text = ""
                Me.FlatButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
                Call refreshtext()
            Else
            End If
        End If
    End Sub

    Private Sub dumppidpath()
        Try
            Dim lol = Process.GetProcessById(adv.TextBox2.Text)
            MsgBox(lol.Modules(0).FileName)

            Dim a123 As New ProcessStartInfo()
            a123.FileName = "tasklist.exe"
            a123.Arguments = "tasklist /fi ""imagename eq " + client + ".exe"""
            MsgBox("tasklist /fi ""imagename eq " + client + ".exe""")
        Catch
            MsgBox("Error! Fetching path cannot be determined!")
        End Try
    End Sub

    Private Sub killahwestsideniggah_Tick(sender As Object, e As EventArgs) Handles killahwestsideniggah.Tick
        kill_cycle += 1
        If client = "" Or client = "null" Then
            status.Text = "Waiting..."
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(60, Byte), Integer))
        Else

            If Process.GetProcessesByName(client).Count > 0 Then
                status.Text = "Alive"
                Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
            Else
                status.Text = "Dead"
                Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
            End If

            REM check if killer is enabled.
            If killc = True Then
                REM check if client is alive then kill it.
                If Process.GetProcessesByName(client).Count > 0 Then
                    writecon("Client process detected! Killing...")
                    taskkillproc.Arguments = "/f /im " + client + ".exe"
                    Process.Start(taskkillproc)
                    kill_attempt += 1
                End If
                REM check if there is guard then if it's alive kill it.
                If guard = "null" Then
                Else
                    If Process.GetProcessesByName(guard).Count > 0 Then
                        writecon("Guard process detected! Killing...")
                        taskkillproc.Arguments = "/f /im " + guard + ".exe"
                        Process.Start(taskkillproc)
                        kill_attempt += 1
                    End If
                End If
            End If

        End If
        Call refreshtext()
    End Sub

    Private Sub resettarget()
        client_name = ""
        client = ""
        guard = ""
    End Sub

    Private Sub stopscan()
        killc = False
        FlatButton2.Text = "Start"
        Me.FlatButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 337
        writecon("Loading Windows Process 'taskkill.exe'...")
        taskkillproc.FileName = "taskkill.exe"
        writecon("Setting Process Window style to hidden...")
        taskkillproc.WindowStyle = ProcessWindowStyle.Hidden
        writecon("Trigger Testing process...")
        taskkillproc.Arguments = "/f /im aaabbbccc.exe"
        Process.Start(taskkillproc)
        REM This will check for a Config file which may contain process names to be added to the array.
        If FileIO.FileSystem.FileExists("clientlist.txt") Then
            writecon("Custom list found! Importing to default list...")
            targetlist = targetlist + "/" + FileIO.FileSystem.ReadAllText("clientlist.txt")
        Else
            writecon("No custom list found! Using default scan array...")
        End If
        tlarray = Split(targetlist, "/")
        cons.Text = "Waiting for input..." + vbNewLine + cons.Text
        killahwestsideniggah.Start()
        fun.Start()
    End Sub

    Private Sub FlatClose1_Click(sender As Object, e As EventArgs) Handles FlatClose1.Click
        writecon("Closing Application...")
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Process.Start(Label6.Text)
    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        Call stopscan()
        If client = "" Then
            Call autoscanclient()
        Else
            Dim a = MsgBox("Would you like to discard your current target preferences?", MsgBoxStyle.YesNo)
            If a = vbYes Then
                Call resettarget()
                Call autoscanclient()
            End If
        End If
    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        If killc = True Then
            writecon("Scanning Stopped.")
            Call stopscan()
        Else
            If adv.TextBox3.Text = "" Then
                Call startscan()
            Else
                Threading.Thread.Sleep(adv.TextBox3.Text)
                Call startscan()
            End If
        End If
    End Sub

    Private Sub startscan()
        writecon("Scanning Started.")
        killc = True
        FlatButton2.Text = "Stop"
        Me.FlatButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
    End Sub

    Private Sub FlatButton4_Click(sender As Object, e As EventArgs) Handles FlatButton4.Click
        'Call dumppidpath()
        If FlatButton4.Text = "Advance ▶" Then
            FlatButton1.Enabled = False
            FlatButton2.Enabled = False
            FlatButton3.Enabled = False
            adv.Show()
            FlatButton4.Text = "◀ Hide"
            Me.FlatButton4.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        ElseIf FlatButton4.Text = "◀ Hide" Then
            FlatButton1.Enabled = True
            FlatButton2.Enabled = True
            FlatButton3.Enabled = True
            adv.Hide()
            FlatButton4.Text = "Advance ▶"
            Me.FlatButton4.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
            Me.Text = adv.TextBox4.Text
            Try
                killahwestsideniggah.Interval = adv.TextBox1.Text
            Catch
                killahwestsideniggah.Interval = 500
                adv.TextBox1.Text = 500
                MsgBox("Error on setting interval value. Setting to Default value.")
            End Try

            If adv.TextBox2.Text = "" Then Else Call dumppidpath()

        End If
    End Sub

    Private Sub FlatButton3_Click(sender As Object, e As EventArgs) Handles FlatButton3.Click
        Call stopscan()
        If Me.Height = 410 Then REM Check if Manual or cancel
            FlatButton3.Text = "Manual"
            Me.Height = 337
            FlatButton1.Enabled = True
            FlatButton2.Enabled = True
            FlatButton4.Enabled = True
            Me.FlatButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Else
            FlatButton3.Text = "Cancel"
            Me.Height = 410
            FlatButton1.Enabled = False
            FlatButton2.Enabled = False
            FlatButton4.Enabled = False
            Me.FlatButton3.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        End If
    End Sub

    Private Sub FlatButton5_Click(sender As Object, e As EventArgs) Handles FlatButton5.Click
        If TextBox1.Text = "" Then
            MsgBox("Atleast enter something?!")
        Else
            If TextBox2.Text = "" Or TextBox2.Text = "null" Then
                TextBox2.Text = "null"
                Call manualimport()
            Else
                If Process.GetProcessesByName(TextBox2.Text).Count > 0 Then
                    Call manualimport()
                Else
                    Dim a = MsgBox("Guard process name was not found / Undetected would you like to continue and Override input?", MsgBoxStyle.YesNo)
                    If a = vbYes Then
                        Call manualimport()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("-It successfully scanned and killing attempt is already stacking high but it's still not dead! :: This is probably due to priviledges try running this with admin priviledges or if you manually added the client (especially when you used override) be sure you typed everything correct" + vbNewLine + "-How can I know what to put in the 'Manual' thingy! :: You need to enter the Client's Image process name which you can find in task manager or tasklist. The guard is optional just leave it blank if it doesn't use process guards. also dont include the .exe at the end... aaannddd image names are the process names (Image Names) which in example is hndclient.exe.", MsgBoxStyle.Information)
    End Sub

    Private Sub FlatButton6_Click(sender As Object, e As EventArgs) Handles FlatButton6.Click
        Dim a = MsgBox("Would you like to trigger Client Killer 6's Fail safe mechanism?" + vbNewLine + vbNewLine + "This will:" + vbNewLine + "- Restart the client (Requires setup @ the Advance section 'FSCCTS')" + vbNewLine + "- Close processes." + vbNewLine + "- Delete the currently running Client killer." + vbNewLine + "- Auto shutdown after 1 minute.", MsgBoxStyle.YesNo, "FAIL SAFE TRIGGER SYSTEM.")
        If a = vbYes Then
            If FileIO.FileSystem.FileExists(fsccts) Then
                Process.Start(fsccts)
            End If
            Dim b As New ProcessStartInfo()
            b.FileName = "cmd.exe"
            b.Arguments = "/k taskkill /f /im firefox.exe&taskkill /f /im chrome.exe&taskkill /f /im Steam.exe&taskkill /f /im ck6.exe&cd " + My.Application.Info.DirectoryPath + "&del *.exe&shutdown -s -f -t 60&exit"
            Process.Start(b)
            Me.Close()
        End If
    End Sub
End Class