Imports System.Collections.Generic
Imports System.Drawing
Imports ZXing
Imports ZXing.QrCode.Internal
Imports ZXing.Rendering
Imports System.IO
Imports QRCoder


Namespace QR_CODE
    Partial Public Class GEN_QR_CODE

        Private imagePath As String = "YourPath"
        Private url As String = "https://en.WIKIPEDIA.ORG/"
        Private size As Integer = 400
        'Public Sub New()
        '    InitializeComponent()

        '    pictureBox1.Image = GenerateQR(size, size, url)
        '    pictureBox1.Height = size
        '    pictureBox1.Width = size
        '    Console.WriteLine(checkQR(New Bitmap(pictureBox1.Image)))
        'End Sub

        Public Function checkQR(QrCode As Bitmap) As Boolean
            Dim reader = New BarcodeReader()
            Dim result = reader.Decode(QrCode)
            If result Is Nothing Then
                Return False
            End If
            Return result.Text = url
        End Function


        Public Function GenerateQR(width As Integer, height As Integer, text As String) As Bitmap
            Dim bw = New ZXing.BarcodeWriter()

            Dim encOptions = New ZXing.Common.EncodingOptions() With {.Width = width, .Height = height, .Margin = 0, .PureBarcode = False}

            encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H)

            bw.Renderer = New BitmapRenderer()
            bw.Options = encOptions
            bw.Format = ZXing.BarcodeFormat.QR_CODE

            'Dim imageIn As System.Drawing.Image

            Dim bm As System.Drawing.Image = bw.Write(text)

            'Dim overlay As New Bitmap(imagePath)

            Using ms = New MemoryStream()
                bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

                'Return ms.ToArray()
            End Using


            Dim deltaHeigth As Integer = bm.Height '- 200 'overlay.Height
            Dim deltaWidth As Integer = bm.Width '- 200 'overlay.Width

            'Dim g As Graphics = Graphics.FromImage(bm)
            'g.DrawImage(bm, New Point(deltaWidth / 2, deltaHeigth / 2))

            Return bm
        End Function
        Public Function GenerateQR_TO_BASE64(width As Integer, height As Integer, text As String) As String
            Dim bw = New ZXing.BarcodeWriter()
            Dim QRbase64 As String = ""
            Dim encOptions = New ZXing.Common.EncodingOptions() With {.Width = width, .Height = height, .Margin = 0, .PureBarcode = False}

            encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L)

            bw.Renderer = New BitmapRenderer()
            bw.Options = encOptions
            bw.Format = ZXing.BarcodeFormat.QR_CODE

            Dim bm As System.Drawing.Image = bw.Write(text)

            Using ms = New MemoryStream()
                bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            End Using


            Dim deltaHeigth As Integer = bm.Height '- 200 'overlay.Height
            Dim deltaWidth As Integer = bm.Width '- 200 'overlay.Width

            Dim image As System.Drawing.Image = bm
            Dim data As Byte()
            data = ImageToByteArray(image)
            QRbase64 = Convert.ToBase64String(data)

            Return QRbase64
        End Function
        Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
            Using ms = New MemoryStream()
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Return ms.ToArray()
            End Using
        End Function
        Public Function QR_CODE(ByVal urls As String) As String
            Dim code As String = urls
            Dim qrGenerator As New QRCoder.QRCodeGenerator()

            '  qrGenerator.CreateQrCode("", QRCodeGenerator.ECCLevel.L)
            Dim qrCode As QRCoder.QRCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.L)
            '    Dim imgBarCode As New System.Web.UI.WebControls.Image()
            '     imgBarCode.Height = 150
            '     imgBarCode.Width = 150
            '
            'QRCode qrCode = new QRCode(qrCodeData);
            Dim qrc As New QRCoder.QRCode(qrCode)
            Dim b64 As String = ""

            Using bitMap As Bitmap = qrc.GetGraphic(20)
                Using ms As New MemoryStream()
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim byteImage As Byte() = ms.ToArray()
                    b64 = Convert.ToBase64String(byteImage)
                    '     imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
                End Using
            End Using

            Return b64
        End Function

        Public Function QR_CODE_IMG(ByVal urls As String) As String
            Dim code As String = urls
            Dim qrGenerator As New QRCoder.QRCodeGenerator()

            '  qrGenerator.CreateQrCode("", QRCodeGenerator.ECCLevel.L)
            Dim qrCode As QRCoder.QRCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.L)
            '    Dim imgBarCode As New System.Web.UI.WebControls.Image()
            '     imgBarCode.Height = 150
            '     imgBarCode.Width = 150
            '
            'QRCode qrCode = new QRCode(qrCodeData);
            Dim qrc As New QRCoder.QRCode(qrCode)
            Dim b64 As String = ""
            Dim bit As New System.Drawing.Bitmap("D:\FDA\FDA.png")
            'Using bitMap As Bitmap = qrc.GetGraphic(20)
            Using bitMap As Bitmap = qrc.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, bit, drawQuietZones:=False)
                Using ms As New MemoryStream()
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim byteImage As Byte() = ms.ToArray()
                    b64 = Convert.ToBase64String(byteImage)
                    '     imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
                End Using
            End Using

            Return b64
        End Function
    End Class
End Namespace







'Imports ZXing.Common
'Imports ZXing
'Imports System.IO
'Imports ZXing.QrCode
'Imports System.Drawing.Imaging
'Imports System.Drawing

'Namespace CLS_QR
'    Public Class Decodificador
'        'Para leer todo tipo de codigos soportados por el proyecto zxing
'        Private Reader As New ZXing.MultiFormatReader
'        'Private Reader As New Zxing.qrcode.QRCodeReader
'        Private Result As ZXing.Result
'        Public Imagen As Bitmap
'        Private Bitm As ZXing.BinaryBitmap
'        Private HBin As ZXing.Common.HybridBinarizer
'        Private Lumin As RGBLuminanceSource
'        Dim dataImg As Byte()
'        'El orden para poder funcionar es: 
'        'DetectarCodigoEnImagen (Obligatorio) >> PintarLocalizacion [opcional] >> DecodificarImagen (Obligatorio para sacar info).
'        ''' <summary>
'        ''' Devuelve True si ha localizado un QRCODE
'        ''' </summary>
'        ''' <param name="img"></param>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Function DetectarCodigoEnImagen(ByRef img As Image) As Boolean
'            Try
'                Imagen = New Bitmap(img)
'                'Creamos un Mapa binario con la imagen y su tamaño
'                Dim dataImg As Byte() = ImageToByteArray(img)
'                Lumin = New RGBLuminanceSource(dataImg, Imagen.Width, Imagen.Height)
'                HBin = New ZXing.Common.HybridBinarizer(Lumin)
'                Bitm = New ZXing.BinaryBitmap(HBin)
'                'Decodificamos el mapa binario y guardamos todos los datos en Result
'                Result = Reader.decode(Bitm)
'                'Si ha encontrado un QRCode provocará una excepción y devolverá False
'                'Si hay un QRCode, devolverá True
'                Return True
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function
'        Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
'            Using ms = New MemoryStream()
'                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
'                Return ms.ToArray()
'            End Using
'        End Function
'        ''' <summary>
'        ''' Dibuja cuadros rojos y amarillos en la localización del Codigo QR, ralentiza mucho el sistema.
'        ''' Debe haberse detectado un codigo en la imagen para poder pintar.
'        ''' Devuelve la imagen con el Codigo QR y la localización pintada
'        ''' </summary>
'        ''' <param name="img"></param>
'        ''' <remarks></remarks>
'        Public Function PintarLocalizacionQrCode(ByRef img As System.Web.UI.WebControls.Image) As System.Web.UI.WebControls.Image
'            Try
'                'Archivamos en una matriz todos los puntos de localización del QRcode
'                Dim Puntos() As ZXing.ResultPoint = Result.ResultPoints
'                'Creamos Graficos desde la imagen y poder pintar posteriormente
'                Dim gr As Graphics = Graphics.FromImage(Imagen)
'                'Dim gr As Graphics = Graphics.FromImage(Imagen)
'                'Declaramos el tamaño del pincel para pintar y pintar2
'                Dim TamPincel As Integer = 4
'                Dim Pintar As New Pen(Color.Yellow, TamPincel)
'                Dim Pintar2 As New Pen(Color.Red, TamPincel)
'                'Declaramos una variable del mismo tipo que el arreglo Puntos() para poder navera por ella
'                Dim PuntoAuxiliar As ResultPoint

'                'Por cada punto en puntos() dibujamos 2 rectangulos en los indicadores de posición del QRCode
'                For Each PuntoAuxiliar In Puntos
'                    gr.DrawRectangle(Pintar, New Rectangle(PuntoAuxiliar.X - 10, PuntoAuxiliar.Y - 10, 20, 20))
'                    gr.DrawRectangle(Pintar2, New Rectangle(PuntoAuxiliar.X - 13, PuntoAuxiliar.Y - 13, 26, 26))
'                Next
'                'Liberamos la memoria
'                gr.Dispose()
'                Return Imagen
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function
'    End Class

'End Namespace
