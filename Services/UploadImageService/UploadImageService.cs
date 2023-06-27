using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Storage;

namespace backend.Services.UploadImageService
{
    public class UploadImageService : IUploadImageService
    {
        private static string apiKey = "AIzaSyDSIzLikOneS5gJv5wki1sdNSO9pkdc01Y";
        private static string Bucket = "restaurantreservation-62b5e.appspot.com";
        private static string AuthEmail = "buithihatien2711@gmail.com";
        private static string AuthPassword = "BTHTien2711@";
        public async Task<string> UploadImage(string folder,string subfolder, string name,IFormFile model)
        {
            string projectPath = System.Environment.CurrentDirectory;
            string folderName = Path.Combine(projectPath, "Image\\");
            System.IO.Directory.CreateDirectory(folderName);

            using (FileStream fileStream= System.IO.File.Create(folderName + model.FileName))
            {
                model.CopyTo(fileStream);
                fileStream.Flush();
            }

            //upload firebase
            if (model.Length > 0)
            {
                FileStream ms = new FileStream(Path.Combine(folderName, model.FileName), FileMode.Open);
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                var cancellation = new CancellationTokenSource();
                var task = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child("restaurant-reservation")
                    .Child(folder)
                    .Child(subfolder)
                    .Child(name)
                    .PutAsync(ms, cancellation.Token);
                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
                try
                {
                    var link = await task;
                    // ms.Close();
                    ms.Dispose();
                    if (System.IO.File.Exists(Path.Combine(folderName, model.FileName)))
                    {
                        System.IO.File.Delete(Path.Combine(folderName, model.FileName));
                    }
                    return link;
                }
                catch (Exception ex)
                {
                    throw new BadHttpRequestException($"Exception was thrown: {ex}");
                }


            }
            throw new BadHttpRequestException("Exception");
        }

        // public async Task<string> UploadImage(string folder, string subfolder, string name, IFormFile model)
        // {
        //     string projectPath = System.Environment.CurrentDirectory;
        //     string folderName = Path.Combine(projectPath, "Image\\");
        //     System.IO.Directory.CreateDirectory(folderName);
        //     using (FileStream fileStream= System.IO.File.Create(folderName + model.FileName))
        //     {
        //         model.CopyTo(fileStream);
        //         fileStream.Flush();
        //     }

        //     var stream = File.Open(Path.Combine(folderName, model.FileName), FileMode.Open);
        //     var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        //     var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

        //     var cancellation = new CancellationTokenSource();
        //     var task = new FirebaseStorage(
        //         Bucket,
        //         new FirebaseStorageOptions
        //         {
        //             AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
        //             ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
        //         })
        //         .Child("restaurant-reservation")
        //         .Child(folder)
        //         .Child(subfolder)
        //         .Child(name)
        //         .PutAsync(stream, cancellation.Token);

        //     task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        //     // cancel the upload
        //     // cancellation.Cancel();

        //     try
        //     {
        //         var link = await task;
        //         stream.Close();
        //         // stream.Dispose();
        //         // if (System.IO.File.Exists(Path.Combine(folderName, model.FileName)))
        //         // {
        //         //     System.IO.File.Delete(Path.Combine(folderName, model.FileName));
        //         // }
        //         return link;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new BadHttpRequestException($"Exception was thrown: {ex}");
        //     }
        // }

        // public async Task<string> UploadImage(string folder, string subfolder, string name, IFormFile model)
        // {
        //     string projectPath = System.Environment.CurrentDirectory;
        //     string folderName = Path.Combine(projectPath, "Image\\");
        //     System.IO.Directory.CreateDirectory(folderName);

        //     byte[] fileBytes;
        //     using (var memoryStream = new MemoryStream())
        //     {
        //         await model.CopyToAsync(memoryStream);
        //         fileBytes = memoryStream.ToArray();
        //     }

        //     // Create a memory stream from the byte array
        //     using (var stream = new MemoryStream(fileBytes))
        //     {
        //         var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        //         var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

        //         var cancellation = new CancellationTokenSource();
        //         var task = new FirebaseStorage(
        //                 Bucket,
        //                 new FirebaseStorageOptions
        //                 {
        //                     AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
        //                     ThrowOnCancel = true
        //                 })
        //             .Child("restaurant-reservation")
        //             .Child(folder)
        //             .Child(subfolder)
        //             .Child(name)
        //             .PutAsync(stream, cancellation.Token);

        //         task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        //         try
        //         {
        //             var link = await task;
        //             return link;
        //         }
        //         catch (Exception ex)
        //         {
        //             throw new BadHttpRequestException($"Exception was thrown: {ex}");
        //         }
        //     }
        // }
    }
}