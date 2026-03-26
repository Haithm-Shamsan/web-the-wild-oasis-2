import { createClient } from "@supabase/supabase-js";


const supabaseUrl = `https://yewzvvzefwgmbycqryqb.supabase.co`;
const supabaseKey = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inlld3p2dnplZndnbWJ5Y3FyeXFiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjY3Mjk2NjUsImV4cCI6MjA0MjMwNTY2NX0.qLHgA7-kdeyYge_sufqcgYt5iz408gFH72uAOaLYkf8'

const supabase = createClient(supabaseUrl, supabaseKey);
 
export default supabase;

export { supabaseUrl };