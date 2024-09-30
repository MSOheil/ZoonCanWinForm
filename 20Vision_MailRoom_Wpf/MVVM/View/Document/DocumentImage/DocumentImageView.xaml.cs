using _20Vision_MailRoom_Wpf_Application.Common.Dto.DocumentImage;
using System.Diagnostics;

namespace _20Vision_MailRoom_Wpf.MVVM.View.Document.DocumentImage;
/// <summary>
/// Interaction logic for DocumentImageView.xaml
/// </summary>
public partial class DocumentImageView : Window
{
    public Guid DocumentId { get; set; }
    private readonly IImageFileOperation imageFileOperation;
    private readonly IFileOperation fileOperation;
    private readonly ImageCount imageCount;
    private readonly ImagePathes imagePathes;
    private List<int> deletedItemList;
    private int ImageCount { get; set; }
    public DocumentImageView()
    {
        InitializeComponent();
        fileOperation = new FileOperation();
        imageFileOperation = new ImageFileOperation();
        imageCount = new ImageCount();
        imagePathes = new ImagePathes();
    }
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    private OpenFileDialog OpenFileDialog()
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Select a picture";
        openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
          "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
          "Portable Network Graphic (*.png)|*.png";
        return openFileDialog;
    }
    private async Task InitialPageAsync()
    {

        try
        {
            deletedItemList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ImageOne_Stack.Visibility = Visibility.Hidden;
            ImageTwo_Stack.Visibility = Visibility.Hidden;
            ImageFive_Stack.Visibility = Visibility.Hidden;
            ImageEight_Stack.Visibility = Visibility.Hidden;
            ImageThree_Stack.Visibility = Visibility.Hidden;
            ImageFoure_Stack.Visibility = Visibility.Hidden;
            ImageSix_Stack.Visibility = Visibility.Hidden;
            ImageSeven_Stack.Visibility = Visibility.Hidden;
            ImageNine_Stack.Visibility = Visibility.Hidden;
            ImageTen_Stack.Visibility = Visibility.Hidden;
            var imageInformation = await imageFileOperation.GetImagebyDocumentIdAsync<List<ShowImageDto>>(new _20Vision_MailRoom_Wpf_Application.Common.Dto.DocumentImage.GetImageInformationByDocumentIdDto
            {
                DocumentId = this.DocumentId
            });
            if (imageInformation is not null)
            {
                for (int i = 0; i < imageInformation.Count; i++)
                {
                    if (i.Equals(0))
                    {
                        imageCount.ImageOne = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        imagePathes.ImagePathOne = imagePath;
                        ImageOne.Source = new BitmapImage(new Uri(imagePath));
                        ImageOne_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(0);
                    }
                    if (i.Equals(1))
                    {
                        imageCount.ImageTwo = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathTwo = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageTwo.Source = new BitmapImage(new Uri(imagePath));
                        ImageTwo_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(1);

                    }
                    if (i.Equals(2))
                    {
                        imageCount.ImageThree = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathThree = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageThree.Source = new BitmapImage(new Uri(imagePath));
                        ImageThree_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(2);
                    }
                    if (i.Equals(3))
                    {
                        imageCount.ImageFoure = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathFoure = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageFoure.Source = new BitmapImage(new Uri(imagePath));
                        ImageFoure_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(3);
                    }
                    if (i.Equals(4))
                    {
                        imageCount.ImageFive = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathFive = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageFive.Source = new BitmapImage(new Uri(imagePath));
                        ImageFive_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(4);
                    }
                    if (i.Equals(5))
                    {
                        imageCount.ImageSix = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathSix = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageSix.Source = new BitmapImage(new Uri(imagePath));
                        ImageSix_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(5);
                    }
                    if (i.Equals(6))
                    {
                        imageCount.ImageSeven = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathSeven = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageSeven.Source = new BitmapImage(new Uri(imagePath));
                        ImageSeven_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        deletedItemList.Remove(6);
                    }
                    if (i.Equals(7))
                    {
                        imageCount.ImageEight = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathEight = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageEight.Source = new BitmapImage(new Uri(imagePath));
                        ImageEight_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(7);
                        ImageCount++;
                    }
                    if (i.Equals(8))
                    {
                        imageCount.ImageNine = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathNine = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageNine.Source = new BitmapImage(new Uri(imagePath));
                        ImageNine_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(8);
                        ImageCount++;
                    }
                    if (i.Equals(9))
                    {
                        imageCount.ImageTen = imageInformation[i].ImageInformationId;
                        var imagePath = Directory.GetCurrentDirectory() + $"\\Images\\{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fffffff")}.{imageInformation[i].ImageSuffix}";
                        imagePathes.ImagePathTen = imagePath;
                        await fileOperation.CreateFileAsync(imagePath, imageInformation[i].ImageFile, Directory.GetCurrentDirectory() + $"\\Images");
                        ImageTen.Source = new BitmapImage(new Uri(imagePath));
                        ImageTen_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(9);
                        ImageCount++;
                    }

                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await InitialPageAsync();
    }
    private async void AddImage(object sender, RoutedEventArgs e)
    {
        await CreateImageAsync(ImageCount);
    }
    private async Task CreateImageAsync(int imageCountNumber)
    {
        var openFileDialog = OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            var resultOfAddImage = await imageFileOperation.CreateImageAsync<Guid>(System.IO.File.ReadAllBytes(openFileDialog.FileName), "A", DocumentId, openFileDialog.SafeFileName, "/api/Image/UploadImage");
            deletedItemList.Sort();
            foreach (var item in deletedItemList)
            {

                switch (item)
                {
                    case 0:
                        ImageOne_Stack.Visibility = Visibility.Visible;
                        ImageCount++;
                        ImageOne.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageOne = resultOfAddImage;
                        imagePathes.ImagePathOne = openFileDialog.FileName;
                        deletedItemList.Remove(0);
                        break;
                    case 1:
                        ImageCount++;
                        ImageTwo.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageTwo = resultOfAddImage;
                        ImageTwo_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathTwo = openFileDialog.FileName;
                        deletedItemList.Remove(1);
                        break;
                    case 2:
                        ImageCount++;
                        ImageThree.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageThree = resultOfAddImage;
                        imagePathes.ImagePathThree = openFileDialog.FileName;
                        ImageThree_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(2);
                        break;
                    case 3:
                        ImageCount++;
                        ImageFoure.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageFoure = resultOfAddImage;
                        imagePathes.ImagePathFoure = openFileDialog.FileName;
                        ImageFoure_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(3);
                        break;
                    case 4:
                        ImageCount++;
                        ImageFive.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageFive = resultOfAddImage;
                        ImageFive_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathFive = openFileDialog.FileName;
                        deletedItemList.Remove(4);
                        break;
                    case 5:
                        ImageCount++;
                        ImageSix.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageSix = resultOfAddImage;
                        ImageSix_Stack.Visibility = Visibility.Visible;
                        deletedItemList.Remove(5);
                        imagePathes.ImagePathSix = openFileDialog.FileName;
                        break;

                    case 6:
                        ImageCount++;
                        ImageSeven.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageSeven = resultOfAddImage;
                        ImageSeven_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathSeven = openFileDialog.FileName;
                        deletedItemList.Remove(6);
                        break;
                    case 7:
                        ImageCount++;
                        ImageEight.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageEight = resultOfAddImage;
                        ImageEight_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathEight = openFileDialog.FileName;
                        deletedItemList.Remove(7);
                        break;
                    case 8:
                        ImageCount++;
                        ImageNine.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageNine = resultOfAddImage;
                        ImageNine_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathNine = openFileDialog.FileName;
                        deletedItemList.Remove(8);
                        break;
                    case 9:
                        ImageCount++;
                        ImageTen.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        imageCount.ImageTen = resultOfAddImage;
                        ImageTen_Stack.Visibility = Visibility.Visible;
                        imagePathes.ImagePathTen = openFileDialog.FileName;
                        deletedItemList.Remove(9);
                        break;
                }
                break;
            }
        }
    }

    private async void AddImageFoure(object sender, MouseButtonEventArgs e)
    {
        await CreateImageAsync(3);
    }
    private async Task<bool> DeleteImageAsync(Guid imageId)
    {
        try
        {
            if (!Guid.Empty.Equals(imageId))
            {
                var resultOfDelete = await imageFileOperation.DeleteImageByImageInformationIdAsync<bool>(new DeleteImageInformationDto
                {
                    ImageInformationId = imageId
                });
                if (resultOfDelete)
                {
                    ImageCount--;
                    return true;
                }
                return false;
            }
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("عکس با موفقیت حذف نشد");
            return await Task.FromResult(false);
        }
    }

    private async void DeleteImage_One(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageOne);
        if (result)
        {
            imageCount.ImageOne = Guid.Empty;
            ImageOne.Source = null;
            ImageOne_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(0);
        }
    }



    private async void EditImage_Two(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathTwo = await EditImageAsync(imageCount.ImageTwo, ImageTwo);
    }

    private async void EditImage_Ten(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathTen = await EditImageAsync(imageCount.ImageTen, ImageTen);
    }

    private async void EditImage_Three(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathThree = await EditImageAsync(imageCount.ImageThree, ImageThree);
    }

    private async void EditImage_Six(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathSix = await EditImageAsync(imageCount.ImageSix, ImageSix);
    }

    private async void EditImage_Seven(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathSeven = await EditImageAsync(imageCount.ImageSeven, ImageSeven);
    }

    private async void EditImage_Onee(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathOne = await EditImageAsync(imageCount.ImageOne, ImageOne);
    }

    private async void EditImage_Nine(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathNine = await EditImageAsync(imageCount.ImageNine, ImageNine);
    }

    private async void EditImage_Four(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathFoure = await EditImageAsync(imageCount.ImageFoure, ImageFoure);
    }

    private async void EditImage_Five(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathFive = await EditImageAsync(imageCount.ImageFive, ImageFive);
    }

    private async void EditImage_Eight(object sender, RoutedEventArgs e)
    {
        imagePathes.ImagePathEight = await EditImageAsync(imageCount.ImageEight, ImageEight);

    }

    private void ShowImageOne(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathOne}", UseShellExecute = true });
    }

    private void ShowImageTwo(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathTwo}", UseShellExecute = true });
    }

    private void ShowImageFive(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathFive}", UseShellExecute = true });
    }

    private void ShowImageEight(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathEight}", UseShellExecute = true });
    }

    private void ShowImageThree(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathThree}", UseShellExecute = true });
    }

    private void ShowImageFoure(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathFoure}", UseShellExecute = true });
    }

    private void ShowImageSix(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathSix}", UseShellExecute = true });
    }

    private void ShowImageSeven(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathSeven}", UseShellExecute = true });
    }

    private void ShowImageNine(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathNine}", UseShellExecute = true });
    }

    private void ShowImageTen(object sender, MouseButtonEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = $"{imagePathes.ImagePathTen}", UseShellExecute = true });
    }

    private async void DeleteImageTwo(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageTwo);
        if (result)
        {
            imageCount.ImageTwo = Guid.Empty;
            ImageTwo.Source = null;
            ImageTwo_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(1);

        }
    }

    private async void DeleteImageFive(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageFive);
        if (result)
        {
            imageCount.ImageFive = Guid.Empty;
            ImageFive.Source = null;
            ImageFive_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(4);
        }
    }

    private async void DeleteImageEight(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageEight);
        if (result)
        {
            imageCount.ImageEight = Guid.Empty;
            ImageEight.Source = null;
            ImageEight_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(7);
        }
    }

    private async void DeleteImageThree(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageThree);
        if (result)
        {
            imageCount.ImageThree = Guid.Empty;
            ImageThree.Source = null;
            ImageThree_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(2);
        }
    }

    private async void DeleteImageSix(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageSix);
        if (result)
        {
            imageCount.ImageSix = Guid.Empty;
            ImageSix.Source = null;
            ImageSix_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(5);
        }
    }

    private async void DeleteImageSeven(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageSeven);
        if (result)
        {
            imageCount.ImageSeven = Guid.Empty;
            ImageSeven.Source = null;
            ImageSeven_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(6);
        }
    }

    private async void DeleteImageNine(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageNine);
        if (result)
        {
            imageCount.ImageNine = Guid.Empty;
            ImageNine.Source = null;
            ImageNine_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(8);
        }
    }

    private async void DeleteImageTen(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageTen);
        if (result)
        {
            imageCount.ImageTen = Guid.Empty;
            ImageTen.Source = null;
            ImageTen_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(9);
        }
    }

    private async void DeleteImageFoure(object sender, RoutedEventArgs e)
    {
        var result = await DeleteImageAsync(imageCount.ImageFoure);
        if (result)
        {
            imageCount.ImageFoure = Guid.Empty;
            ImageFoure.Source = null;
            ImageFoure_Stack.Visibility = Visibility.Hidden;
            deletedItemList.Add(3);
        }
    }

    private async Task<string> EditImageAsync(Guid imageId, System.Windows.Controls.Image imageSource)
    {
        var openFileDialog = OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                if (!Guid.Empty.Equals(imageId))
                {
                    var resultOfDelete = await imageFileOperation.DeleteImageByImageInformationIdAsync<bool>(new DeleteImageInformationDto
                    {
                        ImageInformationId = imageId
                    });
                    imageSource.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    var resultOfAddImage = await imageFileOperation.CreateImageAsync<Guid>(System.IO.File.ReadAllBytes(openFileDialog.FileName), "A", DocumentId, openFileDialog.SafeFileName, "/api/Image/UploadImage");
                    imageId = resultOfAddImage;
                    return openFileDialog.FileName;
                }
                MessageBox.Show("ابتدا عکسی را اضافه کنید سپس میتوانید ان را تغییر دهید");
            }
            catch (Exception)
            {
                MessageBox.Show("ویرایش عکس انجام نشد");
            }
        }
        return string.Empty;
    }
}