Imports System.IO.Ports

Module App
    Const PATH As String = "COM3"
    Const BAUDRATE As Integer = 9600
    Const INTERVAL As Integer = 1000

    Dim port As SerialPort = New SerialPort(PATH, BAUDRATE, Parity.None, 8, StopBits.One)
    Dim info_line As String() = Nothing
    Dim padlen As Integer = 0

    Sub Main(args As String())
        AddHandler Console.CancelKeyPress, Sub(s, e)
                                               port.Close()
                                               Environment.Exit(0)
                                           End Sub
        Try
            port.Open()

            port.Write($"POLL {INTERVAL}" & vbCrLf)
            Task.Delay(100).Wait()
            port.Write("FRAC 2" & vbCrLf)
            Task.Delay(100).Wait()
            port.Write("INFO" & vbCrLf)
            Task.Delay(100).Wait()

            ' NOTE: while the standard approach would be to use Event handler `port.DataReceived`, it has
            ' proven unable to receive non-input driven readout data thus far.
            While port.IsOpen
                handleReceivedData()
            End While
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
    End Sub

    Sub handleReceivedData()
        Dim data As String = port.ReadLine()
        Dim split As String() = data.Replace(", ", ",").Split("*"c)(0).Split(","c)

        If split(0) = "I" Then
            If split(1) = "Product ID" Then
                info_line = split
                padlen = split.Skip(4).OrderByDescending(Function(s) s.Length).First().Length
                Console.WriteLine(String.Join(",", split))
            Else
                Console.WriteLine(split(3))
            End If
            Return
        End If
        If info_line Is Nothing Then
            Console.WriteLine("Awaiting info line...")
            Return
        End If

        Dim device As String = $"{vbCrLf}{vbCrLf}{split(1)} {split(2)}"
        Dim sensors As String() = info_line.Skip(4).Where(Function(v, i) (i Mod 2 < 1)).ToArray()
        Dim values As String() = split.Skip(4).Where(Function(v, i) (i Mod 2 < 1)).ToArray()
        Dim units As String() = split.Skip(4).Where(Function(v, i) (i Mod 2 > 0)).ToArray()

        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {device}")
        For i As Integer = 0 To units.Length - 1
            Console.WriteLine($"{sensors(i).PadRight(padlen + 2)} {values(i)} {units(i)}")
        Next
    End Sub
End Module
