﻿namespace BuildingEnergyCalculator.Helpers
{
    public class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken)
        {
            return $@"<html>
            <head></head>
                <body style="" margin:0; padding:0; font-family: Arial, Helvetica, sans-serif;"">
                    <div style=""height:auto; background:linear-gradient(to top, #c9c9ff 50%, #6e6ef6 90%) no-repeat;width:400px; padding:30px"">
                        <div>
                            <div>
                                <h1>Reset your Password</h1>
                                <hr>
                                <p>You're receiving this e-mail because you requested a password reset for your FUTURE APP account.</p>
                                <p>Please tap the button below to choose a new password</p>
                                <button style=""background-color:red;border:none""
                                    color:black;border-radius:4px;display:block;margin:0 auto;width:50%;text-align:center;text-decoration:none""><a href=""http://localhost:4200/reset?email={email}&code={emailToken}"" target=""_blank"">Reset Password</a><br></button>
                                
                                <p>Kind Regards,<br><br>
                                Future App</p>
                            </div>                
                        </div>
                    </div>                
                </body>
            </html>";
        }
    }
}
