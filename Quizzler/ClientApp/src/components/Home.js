import React, { Component } from 'react';

import { LoginForm } from './LoginForm';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <>
        <LoginForm />
      </>
    );
  }
}
