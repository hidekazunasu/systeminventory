using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace systeminventory_sample.Models.DbFirst
{
    // DbContextを継承したinHouseDbContextクラスの定義
    public partial class inHouseDbContext : DbContext
    {
        // コンストラクター
        public inHouseDbContext()
        {
        }

        // コンストラクター
        public inHouseDbContext(DbContextOptions<inHouseDbContext> options)
            : base(options)
        {
        }

        // ProcessControlテーブルに対応するDbSet
        public virtual DbSet<ProcessControl> ProcessControls { get; set; }

        // inHouseSystemテーブルに対応するDbSet
        public virtual DbSet<inHouseSystem> Systems { get; set; }

        // SystemCategoryテーブルに対応するDbSet
        public virtual DbSet<SystemCategory> SystemCategories { get; set; }

        // DbContextOptionsBuilderに対しての設定
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // データベース接続文字列の設定（ここではSQLite）
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlite("Data Source=inhouse");
        }

        // モデルの生成時に呼び出されるメソッド
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProcessControlテーブルの定義
            modelBuilder.Entity<ProcessControl>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ProcessControl"); // ProcessControlテーブルに対応するテーブル名
            });

            // inHouseSystemテーブルの定義
            modelBuilder.Entity<inHouseSystem>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("system"); // inHouseSystemテーブルに対応するテーブル名

                entity.Property(e => e.ProcessControl).HasColumnType("INT"); // ProcessControlプロパティの型を指定
            });

            // SystemCategoryテーブルの定義
            modelBuilder.Entity<SystemCategory>(entity =>
            {
                entity.HasNoKey(); // 主キーの定義がないことを設定
            });

            // モデル生成完了時の処理（部分メソッド）
            OnModelCreatingPartial(modelBuilder);
        }

        // OnModelCreatingPartialメソッドの宣言（部分メソッド）
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
