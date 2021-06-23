import React, { Component, useState } from 'react';
import axios from 'axios';

import './Login.css';


export function LoginForm() {
    const[userName, setUserName] = useState("");
    const[password, setPassword] = useState("");
    const[data, setData] = useState([]);

    function handleSubmit(e) {
        e.preventDefault();

        if (userName.length > 0 && password.length > 0) {
            
            const res = axios.get('/api/User/' + userName + "/userName", data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(response => {
                if (response.status == 200){
                    var user = response.data;
                }   
            }).catch(error => {
                //setError(true);
                //setErrorText(error.response.data);
            });

        }
    }

    return (
        <>
        <div class="loginForm">
          <div class="container">
            <div class="d-flex justify-content-center h-100">
              <div class="card">
                <div class="card-header">
                  <h3>Sign In</h3>
                  <div class="d-flex justify-content-end social_icon">
                    <span><i class="fab fa-facebook-square"></i></span>
                    <span><i class="fab fa-google-plus-square"></i></span>
                    <span><i class="fab fa-twitter-square"></i></span>
                  </div>
                </div>
                <div class="card-body">
                  <form>
                    <div class="input-group form-group">
                      <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-user"></i></span>
                      </div>
                      <input type="text" class="form-control" placeholder="username" onChange={e => setUserName(e.target.value)}/>
                      
                    </div>
                    <div class="input-group form-group">
                      <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                      </div>
                      <input type="password" class="form-control" placeholder="password" onChange={e => setPassword(e.target.value)}/>
                    </div>
                    <div class="row align-items-center remember">
                      <input type="checkbox" />Remember Me
                    </div>
                    <div class="form-group">
                      <input type="submit" value="Login" class="btn float-right login_btn" onClick={handleSubmit} />
                    </div>
                  </form>
                </div>
                <div class="card-footer">
                  <div class="d-flex justify-content-center links">
                    Don't have an account?<a href="#">Sign Up</a>
                  </div>
                  <div class="d-flex justify-content-center">
                    <a href="#">Forgot your password?</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    );
}