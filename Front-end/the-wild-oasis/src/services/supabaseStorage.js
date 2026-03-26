import supabase from "./SupabaseClient.js"


export async function uploadImage(file, bucketName) {
  if (!file) {
    throw new Error('No file provided');
  }

  try {
    // Generate a unique file name using a timestamp
    const fileName = `${Date.now()}-${file.name}`;

    // Upload the file to Supabase storage
    const { data, error: uploadError } = await supabase.storage
      .from(bucketName)
      .upload(fileName, file);

    if (uploadError) {
      throw new Error(`Error uploading image: ${uploadError.message}`);
    }

    // Get the public URL for the uploaded file
    const { publicURL, error: urlError } = supabase.storage
      .from(bucketName)
      .getPublicUrl(fileName);

    if (urlError) {
      throw new Error(`Error retrieving public URL: ${urlError.message}`);
    }

    console.log('Public URL:', publicURL); // Debugging output
    return publicURL;
  } catch (error) {
    console.error('Failed to upload image:', error);
    throw error;
  }
}

export function createImagePath(ImageName) {
   const imageName = `${Math.random()}-
  ${ImageName}`.replaceAll("/", "");

    const newImagePath = `https://rotktrdqgkzxexxoanfg.supabase.co/storage/v1/object/public/cabin-images/${imageName}`;
 
  return {imageName,newImagePath};
}