import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import { Login } from './Login';
import '@testing-library/jest-dom';

describe('Login komponens', () => {
  test('renderelni kell a felhasználónév és a jelszó mezőket', () => {
    render(<Login />);
    expect(screen.getByPlaceholderText('Felhasználónév')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Jelszó')).toBeInTheDocument();
  });

  test('engedélyeznie kell a űrlapmezők bevitelét', () => {
    render(<Login />);

    const usernameInput = screen.getByPlaceholderText('Felhasználónév');
    const passwordInput = screen.getByPlaceholderText('Jelszó');

    fireEvent.change(usernameInput, { target: { value: 'kerenyir' } });
    fireEvent.change(passwordInput, { target: { value: 'a' } });

    expect(usernameInput.value).toBe('kerenyir');
    expect(passwordInput.value).toBe('a');
  });
});