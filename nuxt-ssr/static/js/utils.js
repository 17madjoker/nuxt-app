// format string from format 79232401122 or +79232401122 or 89232401122 to +7-923-240-1122 or null
export function formatToMobileNumber(str, useCountyCode) {
  if (useCountyCode == undefined) useCountyCode = true;
  var cleaned = ('' + str).replace(/\D/g, '');

  var match = cleaned.match(/^([\+7]|)?([7-8]|)?(\d{3})(\d{3})(\d{2})(\d{2})$/);

  if (match) {
      var intlCode = match[1] || match[2] ? '+7' : null;

      if (!intlCode) return null;

      if (useCountyCode)
          return [intlCode, '-', match[3], '-', match[4], '-', match[5], match[6]].join('');

      return [match[3], '-', match[4], '-', match[5], match[6]].join('');
  }

  return null;
};

// format string from format +7-923-240-1122 to 79232401122 or null
export function formatMobileNumberToDigits(str) {
  var cleaned = ('' + str).replace(/\D/g, '');

  if (str == '')
  return ''

  var match = cleaned.match(/^([\+7]|)?([7-8]|)?(\d{3})(\d{3})(\d{2})(\d{2})$/);

  if (match) {
      var intlCode = match[1] || match[2] ? '7' : null;

      if (!intlCode) return null;

      return [intlCode, match[3], match[4], match[5], match[6]].join('');
  }

  return null;
};