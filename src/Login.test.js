import React from 'react';
import '@testing-library/jest-dom';
import { render, screen, fireEvent } from '@testing-library/react';
import { Login } from './Login';

describe('App komponens', () => {
test('ki kellene renderelni a usernév és a jelszó mezőket', () => {
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