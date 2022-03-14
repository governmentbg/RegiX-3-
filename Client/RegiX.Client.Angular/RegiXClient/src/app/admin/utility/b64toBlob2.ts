export const b64toBlob2 = (base64, type = 'application/octet-stream') =>
  fetch(`data:${type};base64,${base64}`).then(res => res.blob());
