using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using System.Text;

public class logIn : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_Text error;

    public GameObject requestOtpButton;
    public GameObject loginButton;
    public GameObject googleLoginButton;
    public GameObject facebookLoginButton;
    public GameObject signupButton;

    // private string token;

    public GameObject canvas1;
    public GameObject canvas2;

    public Boolean loginCheck()
    {
        Debug.Log("\nUsername: " + username.text + "\nPassword: " + password.text); //debugging
        username.text = username.text.Trim();
        password.text = password.text.Trim();

        if(String.Equals(username.text, "8452020952") && String.Equals(password.text,"3333"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // new function try
    /*async void getOtp()
    {
        string apiUrl = "https://backend-aura-724a9a5935a5.herokuapp.com/api/v1/authentication/login";

        // Create a JSON payload for the request
        string jsonPayload = "{\"mobileNumber\": \"8930154772\"}";

        try
        {
            // Create an instance of HttpClient
            HttpClient client = new HttpClient();

            // Set the content type header
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            // Send the POST request
            HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();
                Debug.Log("Response Content: " + responseContent);
            }
            else
            {
                Debug.Log("Request failed with status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Debug.Log("An error occurred: " + ex.Message);
        }
    }*/

    /*async void getOtp()
    {
        // Create an instance of HttpClient
        HttpClient client = new HttpClient();

        // Define the URL of the API endpoint
        string apiUrl = "https://backend-aura-724a9a5935a5.herokuapp.com/api/v1/authentication/login";

        // Create a JSON payload for the request
        string jsonPayload = "{\"mobileNumber\": \""+username+"\"}";

        try
        {
            // Create a StringContent with the JSON payload
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            // add headers to send to the api call
            content.Headers.Add("Access-Control-Allow-Origin", "*");
            content.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            content.Headers.Add("Content-Security-Policy", "default-src 'self';base-uri 'self';font-src 'self' https: data:;" +
                "form-action 'self';frame-ancestors 'self';img-src 'self' data:;object-src 'none';script-src 'self';" +
                "script-src-attr 'none';style-src 'self' https: 'unsafe-inline';upgrade-insecure-requests");

            // Send the POST request
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            //print the response
            Debug.Log(response);

            // add timeout for 3sec
            client.Timeout = TimeSpan.FromSeconds(3);
            Debug.Log("Timeout: " + client.Timeout);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse the JSON response to extract the token
                // You can use a JSON library for parsing, e.g., Newtonsoft.Json
                // Example assuming you have a TokenResponse class:
                LoginResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                // Access the token
                string token = tokenResponse.data.token;

                // Now, you can store the token and use it for later verification
                Debug.Log("Token: " + token);
            }
            else
            {
                Debug.Log(response.Content.ReadAsStringAsync());
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }*/

    /*async void loginAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, "https://backend-aura-724a9a5935a5.herokuapp.com/api/v1/authentication/login-otp-verify");
        request.Headers.Add("authorization", token);
        var content = new StringContent("{\n    \"otpNumber\": \"3333\"\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }*/

    // public void sendOTP(){ getOtp(); Debug.Log("sendOTP");}

    public void login()
    {
        if(loginCheck())
        {
            Debug.Log("login");
            changeScene();
        }
        else
        {
            error.color = Color.red;
            error.text = "Invalid Credentials";
        }
    }

    public void requestOTP()
    {
        if(username.text == "8452020952")
        {
            Debug.Log("requestOTP");
            error.color = Color.green;
            error.text = "OTP sent to your mobile number";
        }
        else
        {
            error.color = Color.red;
            error.text = "Invalid Mobile Number";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void signUp()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void logInAgain()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Main UI");
    }
}
