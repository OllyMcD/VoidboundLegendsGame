using Microsoft.Xna.Framework;
using TopDownGame;

public static class CollisionDetection
{
    public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
    {
        return rect1.Intersects(rect2);
    }

    // Example method for checking collision between player and enemy
    public static bool PlayerEnemyCollision(Player player, Enemy enemy)
    {
        Rectangle playerRect = new Rectangle(
            (int)player.Position.X,
            (int)player.Position.Y,
            player.Width,
            player.Height
        );

        Rectangle enemyRect = new Rectangle(
            (int)enemy.Position.X,
            (int)enemy.Position.Y,
            enemy.Width,
            enemy.Height
        );

        return playerRect.Intersects(enemyRect);
    }

    // Additional methods as needed for different collision checks
}



