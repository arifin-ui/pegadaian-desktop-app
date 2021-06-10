<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pop_up_perpanjangan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.txthasil = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Labelno = New System.Windows.Forms.Label()
        Me.Labelpinjman = New System.Windows.Forms.Label()
        Me.Labelbunga = New System.Windows.Forms.Label()
        Me.Labeltotalbunga = New System.Windows.Forms.Label()
        Me.Labeltebusan = New System.Windows.Forms.Label()
        Me.Labeltotaltebusan = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(17, 37)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(88, 17)
        Me.Label43.TabIndex = 44
        Me.Label43.Text = "Jatuh Tempo"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker3.CustomFormat = "yyy-MM-dd"
        Me.DateTimePicker3.Enabled = False
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(118, 32)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(230, 25)
        Me.DateTimePicker3.TabIndex = 45
        '
        'txthasil
        '
        Me.txthasil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txthasil.Enabled = False
        Me.txthasil.Location = New System.Drawing.Point(155, 130)
        Me.txthasil.Margin = New System.Windows.Forms.Padding(4)
        Me.txthasil.Name = "txthasil"
        Me.txthasil.Size = New System.Drawing.Size(193, 25)
        Me.txthasil.TabIndex = 46
        Me.txthasil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(118, 97)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(89, 25)
        Me.TextBox2.TabIndex = 48
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(215, 97)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(20, 25)
        Me.TextBox3.TabIndex = 47
        Me.TextBox3.Text = "%"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Tambah Bunga"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(242, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 27)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Hitung"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 133)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Total Bunga"
        '
        'TextBox21
        '
        Me.TextBox21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox21.Enabled = False
        Me.TextBox21.Location = New System.Drawing.Point(118, 130)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(35, 25)
        Me.TextBox21.TabIndex = 55
        Me.TextBox21.Text = "Rp"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(146, 194)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 43)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "SIMPAN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Perpanjangan"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.CustomFormat = "yyy-MM-dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(118, 65)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(230, 25)
        Me.DateTimePicker1.TabIndex = 58
        '
        'Labelno
        '
        Me.Labelno.AutoSize = True
        Me.Labelno.Location = New System.Drawing.Point(393, 267)
        Me.Labelno.Name = "Labelno"
        Me.Labelno.Size = New System.Drawing.Size(34, 17)
        Me.Labelno.TabIndex = 59
        Me.Labelno.Text = "[no]"
        '
        'Labelpinjman
        '
        Me.Labelpinjman.AutoSize = True
        Me.Labelpinjman.Location = New System.Drawing.Point(217, 267)
        Me.Labelpinjman.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labelpinjman.Name = "Labelpinjman"
        Me.Labelpinjman.Size = New System.Drawing.Size(69, 17)
        Me.Labelpinjman.TabIndex = 61
        Me.Labelpinjman.Text = "[pinjman]"
        Me.Labelpinjman.Visible = False
        '
        'Labelbunga
        '
        Me.Labelbunga.AutoSize = True
        Me.Labelbunga.Location = New System.Drawing.Point(152, 267)
        Me.Labelbunga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labelbunga.Name = "Labelbunga"
        Me.Labelbunga.Size = New System.Drawing.Size(57, 17)
        Me.Labelbunga.TabIndex = 62
        Me.Labelbunga.Text = "[bunga]"
        Me.Labelbunga.Visible = False
        '
        'Labeltotalbunga
        '
        Me.Labeltotalbunga.AutoSize = True
        Me.Labeltotalbunga.Location = New System.Drawing.Point(7, 267)
        Me.Labeltotalbunga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labeltotalbunga.Name = "Labeltotalbunga"
        Me.Labeltotalbunga.Size = New System.Drawing.Size(86, 17)
        Me.Labeltotalbunga.TabIndex = 63
        Me.Labeltotalbunga.Text = "[totalbunga]"
        Me.Labeltotalbunga.Visible = False
        '
        'Labeltebusan
        '
        Me.Labeltebusan.AutoSize = True
        Me.Labeltebusan.Location = New System.Drawing.Point(86, 267)
        Me.Labeltebusan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labeltebusan.Name = "Labeltebusan"
        Me.Labeltebusan.Size = New System.Drawing.Size(67, 17)
        Me.Labeltebusan.TabIndex = 64
        Me.Labeltebusan.Text = "[tebusan]"
        Me.Labeltebusan.Visible = False
        '
        'Labeltotaltebusan
        '
        Me.Labeltotaltebusan.AutoSize = True
        Me.Labeltotaltebusan.Location = New System.Drawing.Point(281, 267)
        Me.Labeltotaltebusan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labeltotaltebusan.Name = "Labeltotaltebusan"
        Me.Labeltotaltebusan.Size = New System.Drawing.Size(105, 17)
        Me.Labeltotaltebusan.TabIndex = 65
        Me.Labeltotaltebusan.Text = "[total+tebusan]"
        Me.Labeltotaltebusan.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Labelno)
        Me.GroupBox1.Controls.Add(Me.Labeltotaltebusan)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox1.Controls.Add(Me.Labeltebusan)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.Labeltotalbunga)
        Me.GroupBox1.Controls.Add(Me.txthasil)
        Me.GroupBox1.Controls.Add(Me.Labelbunga)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Labelpinjman)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox21)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 267)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Perpanjanagan Pegadaian"
        '
        'pop_up_perpanjangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 267)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "pop_up_perpanjangan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perpanjangan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txthasil As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Labelno As System.Windows.Forms.Label
    Friend WithEvents Labelpinjman As System.Windows.Forms.Label
    Friend WithEvents Labelbunga As System.Windows.Forms.Label
    Friend WithEvents Labeltotalbunga As System.Windows.Forms.Label
    Friend WithEvents Labeltebusan As System.Windows.Forms.Label
    Friend WithEvents Labeltotaltebusan As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
