import { test, expect } from '@playwright/test';

test('Github test', async ({ page }) => {

  // Go to https://github.com/
  await page.goto('https://github.com/');

  // Click text=Sign in
  await page.locator('text=Sign in').click();
  await expect(page).toHaveURL('https://github.com/login');

  // Click input[name="password"]
  await page.locator('input[name="password"]').click();

  // Fill input[name="password"]
  await page.locator('input[name="password"]').fill('SteelCurtain75');

  // Press Enter
  await page.locator('input[name="password"]').press('Enter');
  await expect(page).toHaveURL('https://github.com/session');

});