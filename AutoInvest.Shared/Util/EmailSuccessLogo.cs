using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.Util
{
    public static class EmailSuccessLogo
    {

        public const string htmlVerified = @"
                <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Email Verified</title>
                        <style>
                            /* Center the verification container */
                            body {
                                display: flex;
                                justify-content: center;
                                align-items: center;
                                height: 100vh;
                                margin: 0;
                            }

                            /* Style for the white background with shadow */
                            .verification-container {
                                background-color: #ffffff;
                                padding: 20px;
                                text-align: center;
                                border-radius: 5px;
                                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                            }

                            /* Style for the checkmark icon */
                            .checkmark {
                                font-size: 48px;
                                color: #00cc00; /* Green color for the checkmark */
                            }

                            /* Style for the ""Email Verified"" text */
                            .verified-text {
                                font-size: 24px;
                                color: #333333;
                                margin-top: 10px;
                            }

                            /* Style for the ""Welcome to DropMate Delivery"" text */
                            .dropmate-text {
                                font-size: 28px;
                                color: #333333;
                                margin-top: 10px;
                                font-weight: bold;
                            }
                        </style>
                    </head>
                    <body>
                        <div class=""verification-container"">
                            <!-- Checkmark icon -->
                            <div class=""checkmark"">&#10003;</div>
        
                            <!-- ""Email Verified"" text -->
                            <div class=""verified-text"">Verified Successfully</div>
        
                            <!-- ""Welcome to DropMate Delivery"" text -->
                            <div class=""dropmate-text"">Welcome to AutoInvest</div>
                        </div>
                    </body>
                    </html>";
        public const string htmlFailed = @"
                <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Email Verified</title>
                        <style>
                            /* Center the verification container */
                            body {
                                display: flex;
                                justify-content: center;
                                align-items: center;
                                height: 100vh;
                                margin: 0;
                            }

                            /* Style for the white background with shadow */
                            .verification-container {
                                background-color: #ffffff;
                                padding: 20px;
                                text-align: center;
                                border-radius: 5px;
                                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                            }

                            /* Style for the checkmark icon */
                            .checkmark {
                                font-size: 48px;
                                color: #FF0000; /* Green color for the checkmark */
                            }

                            /* Style for the ""Email Verified"" text */
                            .verified-text {
                                font-size: 24px;
                                color: #333333;
                                margin-top: 10px;
                            }

                            /* Style for the ""Welcome to DropMate Delivery"" text */
                            .dropmate-text {
                                font-size: 28px;
                                color: #333333;
                                margin-top: 10px;
                                font-weight: bold;
                            }
                        </style>
                    </head>
                    <body>
                        <div class=""verification-container"">
                            <!-- Checkmark icon -->
                            <div class=""checkmark"">&#10003;</div>
        
                            <!-- ""Email Verified"" text -->
                            <div class=""verified-text"">Verification Unsuccessful</div>
        
                            <!-- ""Welcome to DropMate Delivery"" text -->
                            <div class=""dropmate-text"">Failed to verify</div>
                        </div>
                    </body>
                    </html>";

    }
}
